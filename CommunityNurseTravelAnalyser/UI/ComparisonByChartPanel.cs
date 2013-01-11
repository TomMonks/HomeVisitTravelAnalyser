using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeVisitTravelAnalyser.UI
{
    public partial class ComparisonByChartPanel : UserControl
    {
        public ComparisonByChartPanel()
        {
            InitializeComponent();
        }


        public void Setup(List<double> series1, List<double> series2, List<string> xlabels)
        {
            var s1 = this.chart1.Series[0];
            s1.LegendText = "by home postcode";
            var s2 = this.chart1.Series.Add("by GP postcode");

            s1.AxisLabel = "Distance (m), test, test2";
           

            for (int i = 0; i < series1.Count; i++)
            {
                s1.Points.Add(series1[i]);
                s2.Points.Add(series2[i]);
                s1.Points[i].AxisLabel = xlabels[i];
            }

            this.chart1.ChartAreas[0].AxisY.Title = "Mean Distance (m)";

        }
    }
}
