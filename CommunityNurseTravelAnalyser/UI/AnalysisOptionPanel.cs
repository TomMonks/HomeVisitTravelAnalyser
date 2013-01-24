using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeVisitTravelAnalyser.Analysis;

namespace HomeVisitTravelAnalyser.UI
{
    public partial class AnalysisOptionPanel : UserControl, HomeVisitTravelAnalyser.Analysis.ITSPOptions
    {
        protected const string OD_TEXT = "Ordinary decent swaps the position of one city with all other cities until it reaches the first improvement in the objective function. \n\nThe tour is then set to the improved solution and the search begins from the next city. \n\nStopping Criterion: a single pass reveals no further improvement";
        protected const string SD_TEXT = "Steepest decent swaps the position of one city with all other cities until it reaches an improvement in the objective function. This is then saved as a potential move. \n\nThe algorithm then continues swapping the selected city with all other cities noting and potential moves that improve the objective.  The best move is then selected. \n\nThe tour is then set to the improved solution and the search begins from the next city. \n\nStopping Criterion: a single pass reveals no further improvement";
        protected const string BF_TEXT = "Enumerate all possible combinations of a tour and select the shortest.  WARNING. This approach rapidly becomes slow when the tour is for more than 5 cities (120 combinations)";
        
        public AnalysisOptionPanel()
        {
            InitializeComponent();
        }

        public bool CentroidAnalysis { get { return this.chk_Dispersion.Checked; } }
        public bool DistanceAnalysis { get { return this.chk_Distance.Checked; } }
        public bool OrdinaryDecent {get {return this.rd_ordinarydecent.Checked; }}

        public bool DailyCentroidMethod { get { return this.rd_centroidDay.Checked; } }

        public int TourLength { get { return Convert.ToInt32(this.txt_cities.Text); } }
        public int Sample { get { return Convert.ToInt32(this.txt_samples.Text); } }
        public int Seed { get { return Convert.ToInt32(this.txt_seed.Text); } }

        public BaseSetup TourBaseSetup {
            
            get
            {
                if (this.rb_baseCentroid.Checked)
                {
                    return BaseSetup.LocalityCentroid;
                }
                else if (this.rb_baseRandom.Checked)
                {
                    return BaseSetup.RandomWithinLocality;
                }
                else
                {
                    return BaseSetup.SpecifiedLocalityHub;
                }
            }
        
        }

        private void chk_Distance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_Distance.Checked)
            {
                this.grp_TSP.Enabled = true;
            }
            else
            {
                this.grp_TSP.Enabled = false;
            }
               
        }

        private void rd_ordinarydecent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rd_ordinarydecent.Checked)
            {
                this.richTextBox1.Text = OD_TEXT;

            }
            else if (this.rd_steepestdecent.Checked)
            {
                this.richTextBox1.Text = SD_TEXT;
            }
            else
            {
                this.richTextBox1.Text = BF_TEXT;
            }
        }

        private void AnalysisOptionPanel_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = OD_TEXT;
        }

        private void chk_Dispersion_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Dispersion.Checked)
            {
                this.groupBox1.Enabled = true;
            }
            else
            {
                this.groupBox1.Enabled = false;
            }
        }

 
//public bool OrdinaryDecent { get { return this.rd_ordinarydecent.Checked; } }
        public SearchMethod TourSearchMethod
        {
            get
            {
                if (this.rd_ordinarydecent.Checked)
                {
                    return SearchMethod.OrdinaryDecent;
                }
                else if (this.rd_steepestdecent.Checked)
                {
                    return SearchMethod.SteepestDecent;
                }
                else
                {
                    return SearchMethod.BruteForce;
                }
            }
        }
    }
}
