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
    public partial class LocalityQuerySetupPanel : UserControl, ILocalityQuerySetup 
    {

        protected List<string> localities;
        protected List<string> fields;
        protected Dictionary<string, string> mappings;

        public LocalityQuerySetupPanel()
        {
            InitializeComponent();
            this.txtFile.Text = AppDomain.CurrentDomain.BaseDirectory + "Database\\CommunityNurse.accdb";
            localities = new List<string>();
            fields = new List<string>();
            mappings = new Dictionary<string, string>();

            foreach (ListViewItem item in this.lvw_Locality.Items)
            {
                localities.Add(item.SubItems[0].Text);
            }

            foreach (ListViewItem item in this.listView1.Items)
            {
                fields.Add(item.SubItems[0].Text);
            }

            
            foreach (ListViewItem item in this.lvw_mappings.Items)
            {
                mappings.Add(item.SubItems[0].Text, item.SubItems[1].Text);
            }


        }

        /// <summary>
        /// The database path
        /// </summary>
        public string DatabasePath { get { return this.txtFile.Text; } }

        /// <summary>
        /// The source table to query
        /// </summary>
        public string SourceTable { get { return this.txtTable.Text; } }


        /// <summary>
        /// Start date of query
        /// </summary>
        public DateTime FromDate { get { return this.dateFrom.Value; } }
        

        /// <summary>
        /// End date of query
        /// </summary>
        public DateTime ToDate { get { return this.dateTo.Value; } }


        /// <summary>
        /// The fields selected
        /// </summary>
        public List<string> SelectedFields
        {
            get
            {
              return fields;
            }
        }


        /// <summary>
        /// The selected localities
        /// </summary>
        public List<string> SelectedLocalities
        {
            get
            {
                return localities;
            }
        }


        public Dictionary<string, string> FieldMappings
        {
            get
            {
                
                return mappings;
            }
            set
            {

                this.lvw_mappings.Items.Clear();
                this.mappings = value;

                foreach (var pair in value)
                {
                    var item = new ListViewItem(pair.Key);
                    item.SubItems.Add(pair.Value);
                    this.lvw_mappings.Items.Add(item);
                }
            }
        }

        private void bt_file_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.openFileDialog1.DefaultExt = "Access Database | *.accdb";

            var result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtFile.Text = this.openFileDialog1.FileName;
            }
        }
    }
}
