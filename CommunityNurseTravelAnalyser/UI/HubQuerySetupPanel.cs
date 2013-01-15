using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HomeVisitTravelAnalyser.Query;

namespace HomeVisitTravelAnalyser.UI
{
    public partial class HubQuerySetupPanel : UserControl
    {

        protected List<string> fields;

        public HubQuerySetupPanel()
        {
            InitializeComponent();
            fields = new List<string>();

            foreach (ListViewItem item in this.lvw_hubSelectedFields.Items)
            {
                fields.Add(item.SubItems[0].Text);
            }
        }

        public string DatabasePath
        {
            get;
            set;
        }

        public string SourceTable
        {
            get
            {
                return this.txthubTable.Text;
            }
            set
            {
                this.txthubTable.Text = value;
            }
        }

     

        public List<string> SelectedFields
        {
            get { return fields; }
            set { this.fields = value; }
        }

    
    }
}
