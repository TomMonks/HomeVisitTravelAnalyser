using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CommunityNurseTravelAnalyser.Results;

namespace CommunityNurseTravelAnalyser.UI
{
    public partial class LocalityResultsPanel : UserControl
    {
        public LocalityResultsPanel()
        {
            InitializeComponent();
        }

        public string ResultsGroupName
        {
            get
            {
                return this.groupBox1.Text;
            }
            set
            {
                this.groupBox1.Text = value;
            }
            
        }

        public void SetResults(List<LocalityResult> results)
        {
            var bs = new BindingSource();

            foreach (var result in results)
            {
                bs.Add(result);
            }

            this.dg_patientlocality.DataSource = bs;
        }
        
        public List<LocalityResult> GetResults()
        {
            var results = new List<LocalityResult>();

            foreach (var result in (BindingSource)this.dg_patientlocality.DataSource)
            {
                results.Add((LocalityResult)result);
            }

            return results;
        }
        
    }
}
