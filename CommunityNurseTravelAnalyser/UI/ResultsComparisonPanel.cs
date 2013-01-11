using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunityNurseTravelAnalyser.UI
{
    public partial class ResultsComparisonPanel : UserControl
    {
        public ResultsComparisonPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the results for patients allocted to locality by GP postcode
        /// </summary>
        /// <param name="results">A list of results for each locality</param>
        public void SetGPResults(List<Results.LocalityResult> results)
        {
            this.localityResultsPanel2.SetResults(results);
        }


        /// <summary>
        /// Load the results for patients allocted to locality by patient home postcode
        /// </summary>
        /// <param name="results">A list of results for each locality</param>
        public void SetPatientResults(List<Results.LocalityResult> results)
        {
            this.localityResultsPanel1.SetResults(results);
        }
        
        public List<Results.LocalityResult> GetHomeResults(){
        	return this.localityResultsPanel1.GetResults();
        }

        public List<Results.LocalityResult> GetGPResults(){
        	return this.localityResultsPanel2.GetResults();
        }


    }
}
