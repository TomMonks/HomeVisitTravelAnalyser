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

        
        public void SetResults(List<LocalityResult> home, List<LocalityResult> gp, List<string> selectedLocalities)
        {
            LoadChart(home, gp, selectedLocalities);
            DisplayLocalityStatistics(home, gp);
            DisplayHighLevelStatistics();
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

        private void DisplayHighLevelStatistics()
        {
            var allocationStats = new List<BasicStatistics>();
            allocationStats.Add(new BasicStatistics(series1));
            allocationStats.Add(new BasicStatistics(series2));

            List<AllocationResult> results = new List<AllocationResult>();
            allocationStats.ForEach(x => results.Add(new AllocationResult() 
            { 
                Mean = Math.Round(x.Mean, DECIMAL_PLACES), 
                LCI = Math.Round((new ConfidenceIntervalStandardNormal(x)).LowerBound, DECIMAL_PLACES), 
                UCI = Math.Round((new ConfidenceIntervalStandardNormal(x)).UpperBound, DECIMAL_PLACES) 
            }));

            results[0].AllocationName = "Home Allocation";
            results[1].AllocationName = "GP Allocation";
            this.allocationResultsPanel1.SetResults(results);

            DisplayDifferences(allocationStats, results);

        }

        private void DisplayDifferences(List<BasicStatistics> allocationStats, List<AllocationResult> results)
        {
           
            var diffCI = new ConfidenceIntervalForMeanDifference(allocationStats[0], allocationStats[1]);
            var differences = new List<AllocationResult>();
            differences.Add(new AllocationResult() { AllocationName = "Metres", Mean = diffCI.Mean, LCI = diffCI.LowerBound, UCI = diffCI.UpperBound });
            differences.Add(new AllocationResult() { AllocationName = "%", Mean = (diffCI.Mean / results[0].Mean) * 100, LCI = (diffCI.LowerBound / results[0].LCI) * 100, UCI = (diffCI.UpperBound / results[0].UCI) * 100 });

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

        



    }
}
