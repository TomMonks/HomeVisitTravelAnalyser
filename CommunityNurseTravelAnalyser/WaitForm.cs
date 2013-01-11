using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRG.Controls.UI;

using System.IO;
using LocalSearch;

using HomeVisitTravelAnalyser.UI;

namespace HomeVisitTravelAnalyser
{
  
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();

            this.loadingCircle1.Active = true;

        }

        public void UpdateMessage(object sender, BackgroundEventArgs args)
        {
            this.label1.Text = args.Message;
        }

    }

    
}
