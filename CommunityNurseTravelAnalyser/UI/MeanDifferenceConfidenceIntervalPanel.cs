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

using Statistics.Comparisons.Parametric;

namespace HomeVisitTravelAnalyser.UI
{
    public partial class MeanDifferenceConfidenceIntervalPanel : UserControl
    {
        public MeanDifferenceConfidenceIntervalPanel()
        {
            InitializeComponent();
        }




        
        public List<AllocationResult> GetResults(){
                List<AllocationResult> results = new List<AllocationResult>();

                foreach (var result in (BindingSource)this.dataGridView1.DataSource)
                {
                    results.Add((AllocationResult)result);
                }

                return results;
        }
        
        public void SetResults(List<AllocationResult> results){
        	                var bs = new BindingSource();

                foreach (var result in results)
                {
                    bs.Add(result);
                }

                this.dataGridView1.DataSource = bs;
        }
        
    }
}
