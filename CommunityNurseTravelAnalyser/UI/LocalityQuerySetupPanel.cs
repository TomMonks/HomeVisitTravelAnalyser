using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using HomeVisitTravelAnalyser.Query;

namespace HomeVisitTravelAnalyser.UI
{

    public partial class LocalityQuerySetupPanel : UserControl, ILocalityQuerySetup
    {

        const string DB_PATH = "Path";
        const string SOURCE_TABLE = "Source";
        const string FROM_DATE = "From";
        const string TO_DATE = "To";
        const string FIELDS = "Fields";
        const string LOCALITIES = "Localities";

        const int MAX_RECENT_FILES = 5;

        protected List<string> localities;
        protected List<string> fields;
        protected Dictionary<string, string> mappings;
        protected List<string> recentFiles;


        public LocalityQuerySetupPanel()
        {
            InitializeComponent();
            InitialiseQuerySetupGUI();
        }

        private void InitialiseQuerySetupGUI()
        {
            this.txtFile.Text = AppDomain.CurrentDomain.BaseDirectory + "Database\\MentalHealth.accdb";
            localities = new List<string>();
            fields = new List<string>();
            mappings = new Dictionary<string, string>();
            recentFiles = new List<string>();

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




        public UserQuerySettings Settings
        {
            get
            {
                var settings = new UserQuerySettings();
                settings.DatabasePath = this.DatabasePath;
                settings.SourceTable = this.SourceTable;
                settings.ToDate = this.ToDate;
                settings.FromDate = this.FromDate;
                settings.DateFieldName = this.DateFieldName;

                settings.RecentFiles = this.txtFile.RecentFiles;

                return settings;
                
            }
            set
            {
                this.DatabasePath = value.DatabasePath;
                this.hubQuerySetupPanel1.DatabasePath = value.DatabasePath;
                this.SourceTable = value.SourceTable;
                this.ToDate = value.ToDate;
                this.FromDate = value.FromDate;
                this.DateFieldName = value.DateFieldName;
                this.txtFile.RecentFiles = value.RecentFiles;
            }
        }


        public UserQuerySettings HubSettings
        {
            get
            {
                var settings = new UserQuerySettings();
                settings.DatabasePath = this.DatabasePath;
                settings.SourceTable = this.hubQuerySetupPanel1.SourceTable;
                settings.SelectedFields = this.hubQuerySetupPanel1.SelectedFields;
                
                return settings;
            }
        }

        /// <summary>
        /// The database path
        /// </summary>
        public string DatabasePath { get { return this.txtFile.Text; } set { this.txtFile.Text = value; } }

        /// <summary>
        /// The source table to query
        /// </summary>
        public string SourceTable { get { return this.txtTable.Text; } set { this.txtTable.Text = value; } }


        /// <summary>
        /// The name of the date field in teh database.
        /// </summary>
        public string DateFieldName { get { return this.txt_DateFieldName.Text; } set { this.txt_DateFieldName.Text = value; } }

        /// <summary>
        /// Start date of query
        /// </summary>
        public DateTime FromDate { get { return this.dateFrom.Value; } set { this.dateFrom.Value = value; } }
        

        /// <summary>
        /// End date of query
        /// </summary>
        public DateTime ToDate { get { return this.dateTo.Value; } set { this.dateTo.Value = value; } }


        /// <summary>
        /// The fields selected
        /// </summary>
        public List<string> SelectedFields
        {
            get
            {
              return fields;
            }
            set
            {
                this.fields = value;


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

        public string HubSourceTable
        {
            get { return this.hubQuerySetupPanel1.SourceTable; }
            set { this.hubQuerySetupPanel1.SourceTable = value; }
        }

        public List<string> HubSelectedFields
        {
            get { return this.hubQuerySetupPanel1.SelectedFields; }
            set { this.hubQuerySetupPanel1.SelectedFields = value; }
        }


        private void bt_file_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.openFileDialog1.Filter = "Access Database (*.accdb) | *.accdb";
            this.openFileDialog1.FilterIndex = 1;
            this.openFileDialog1.FileName = "";

            var result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtFile.Text = this.openFileDialog1.FileName;
                this.txtFile.AppendRecentFile(this.openFileDialog1.FileName);
            }

            
            
          
        }

      





 

        
    }
}
