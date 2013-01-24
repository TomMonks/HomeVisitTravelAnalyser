using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HomeVisitTravelAnalyser.Results;
using Statistics.Descriptive;
using Statistics.Comparisons.Parametric;
using EasyExcel;
using EasyExcel.Format;

using System.Reflection;

namespace HomeVisitTravelAnalyser.UI
{
    public partial class ResultsPanel : UserControl
    {
        private const int DECIMAL_PLACES = 1;

        List<double> series1 = new List<double>();
        List<double> series2 = new List<double>();

        public ResultsPanel()
        {
            InitializeComponent();
        }

        public string ResultsDescription { get; set; }

        
        public void SetResults(ResultsContainer results, List<string> selectedLocalities)
        {

            LoadChart(results.HomeResultsByLocality, results.GPResultsByLocality, selectedLocalities);
            DisplayLocalityStatistics(results.HomeResultsByLocality, results.GPResultsByLocality);
            DisplayHighLevelStatistics(results);

            DisplayDifferences(results);

        }

        private void LoadChart(List<LocalityResult> home, List<LocalityResult> gp, List<string> selectedLocalities)
        {
          
            home.ForEach(x => series1.Add(x.Mean));
            gp.ForEach(x => series2.Add(x.Mean));
            this.comparisonByChartPanel1.Setup(series1, series2, selectedLocalities);
        }

        private void DisplayLocalityStatistics(List<LocalityResult> home, List<LocalityResult> gp)
        {
            this.resultsComparisonPanel1.SetPatientResults(home);
            this.resultsComparisonPanel1.SetGPResults(gp);
        }

        private void DisplayHighLevelStatistics(ResultsContainer allResults)
        {
            List<AllocationResult> results = new List<AllocationResult>();
            results.Add(allResults.HomeAllocation);
            results.Add(allResults.GPAllocation);

            results[0].AllocationName = "Home Allocation";
            results[1].AllocationName = "GP Allocation";

            this.allocationResultsPanel1.SetResults(results);

            



        }

        private void DisplayDifferences(ResultsContainer results)
        {

            var diffCI = new ConfidenceIntervalForMeanDifference(results.HomeAllocation.Stats, results.GPAllocation.Stats);
            var differences = new List<AllocationResult>();
            differences.Add(new AllocationResult() { AllocationName = "Metres", Mean = diffCI.Mean, LCI = diffCI.LowerBound, UCI = diffCI.UpperBound });
            differences.Add(new AllocationResult() { AllocationName = "%", Mean = (diffCI.Mean / results.HomeAllocation.Mean) * 100, LCI = (diffCI.LowerBound / results.HomeAllocation.Mean) * 100, UCI = (diffCI.UpperBound / results.HomeAllocation.Mean) * 100 });

            this.meanDifferenceConfidenceIntervalPanel1.SetResults(differences);
        }

 

		private DataTable ConvertListOfObjectsToDataTable(List<LocalityResult> results)
        {
            
            Type type = results[0].GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            var table = new DataTable();

            foreach (PropertyInfo prop in props)
            {
                
                table.Columns.Add(prop.Name);
            }


            foreach (var result in results)
            {

                var newRow = table.NewRow();

                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(result, null);

                    newRow[prop.Name] = propValue;
                    
                }

                table.Rows.Add(newRow);
            }

            return table;
        }


         
        void ExportResultsToExcelToolStripMenuItemClick(object sender, EventArgs e)
        {
            ExcelWorkBookAdaptor wbk = new ExcelWorkBookAdaptor();
            wbk.NewBook();

            ExportResultsToExcel(wbk, this.allocationResultsPanel1.GetResults(), new ExcelCellCoordinate(1, 1));
            ExportResultsToExcel(wbk, this.meanDifferenceConfidenceIntervalPanel1.GetResults(), new ExcelCellCoordinate(5, 1));

            ExportResultsToExcel(wbk, this.resultsComparisonPanel1.GetHomeResults(), new ExcelCellCoordinate(1, 7));
            ExportResultsToExcel(wbk, this.resultsComparisonPanel1.GetGPResults(), new ExcelCellCoordinate(10, 7));

            wbk[0].Name = this.ResultsDescription.Substring(0, Math.Min(30, this.ResultsDescription.Length));
            wbk.Show();

        }



        


        private void ExportResultsToExcel<T>(ExcelWorkBookAdaptor wbk, List<T> results, ExcelCellCoordinate coord)
        {
            var pipe = new ObjectPropertiesToExcelAdapter<T>(wbk[0], results);
            pipe.Write(coord);

            ExcelCellCoordinate bottomRight = new ExcelCellCoordinate(coord.Row + results.Count, coord.Col + PropertyCount(results) -1);
            ExcelRangeTableStyle style = new ExcelRangeTableStyle(wbk[0], coord, bottomRight) { FirstRowContainHeaders = true };
            style.Execute();

        }

        private int PropertyCount<T>(List<T> results)
        {
            Type type = results[0].GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            return props.Count;
        }

        private void exportDetailedLocalityDataToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void tabularFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportLocalityDetailToExcelTabular();
        }


        void ExportLocalityDetailToExcelTabular()
        {
            ExcelWorkBookAdaptor wbk = new ExcelWorkBookAdaptor();
            wbk.NewBook();

            ExportListResultsToExcel(wbk, 0, this.resultsComparisonPanel1.GetHomeResults());
            ExportListResultsToExcel(wbk, 1, this.resultsComparisonPanel1.GetGPResults());

            wbk[0].Name = "Home";
            wbk[1].Name = "GP";


            wbk.Show();
        }

        private void ExportListResultsToExcel(ExcelWorkBookAdaptor wbk, int sheetIndex, List<LocalityResult> results)
        {
            int column = 1;

            foreach (var result in results)
            {
                var pipe = new ListToExcelTableAdaptor<double>(wbk[sheetIndex], result.Data);
                pipe.Write(new ExcelCellCoordinate(1, column++), 1);
            }
        }










        void ExportLocalityDetailToExcelSPSS()
        {
            ExcelWorkBookAdaptor wbk = new ExcelWorkBookAdaptor();
            wbk.NewBook();
            wbk.Show();
            int row = 1;

            ExportListResultsToExcelSPSS(wbk, this.resultsComparisonPanel1.GetHomeResults(), 1, ref row);
            ExportListResultsToExcelSPSS(wbk, this.resultsComparisonPanel1.GetGPResults(), 2, ref row);

            wbk[0].Name = "Home";
            wbk[1].Name = "GP";


            wbk.Show();
        }

        private void ExportListResultsToExcelSPSS(ExcelWorkBookAdaptor wbk, List<LocalityResult> results, int policyIndex, ref int row)
        {
            
            

            int localityIndex = 1;

            var policyIndexList = new List<int>();
            Enumerable.Range(0, results[0].Data.Count).ToList().ForEach(x => policyIndexList.Add(policyIndex));
            

            foreach (var result in results)
            {
                var startRow = row;

                var pipe = new ListToExcelTableAdaptor<double>(wbk[0], result.Data);
                pipe.Write(new ExcelCellCoordinate(startRow, 1), 1);
                
                startRow = row;

                var policyPipe = new ListToExcelTableAdaptor<int>(wbk[0], policyIndexList);
                policyPipe.Write(new ExcelCellCoordinate(startRow, 2), 1);

                startRow = row;

                var localityIndexList = new List<int>();
                Enumerable.Range(0, results[0].Data.Count).ToList().ForEach(x => localityIndexList.Add(localityIndex));
                
                var localityPipe = new ListToExcelTableAdaptor<int>(wbk[0], localityIndexList);
                localityPipe.Write(new ExcelCellCoordinate(startRow, 3), 1);

                row += result.Data.Count;
                localityIndex++;
            }

            
        }

        private void exportInSTATASPSSFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportLocalityDetailToExcelSPSS();
        }


    }
}
