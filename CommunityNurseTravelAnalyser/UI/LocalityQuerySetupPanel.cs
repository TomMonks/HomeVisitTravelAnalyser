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
    [Serializable]
    public partial class LocalityQuerySetupPanel : UserControl, ILocalityQuerySetup, ISerializable
    {

        const string DB_PATH = "Path";
        const string SOURCE_TABLE = "Source";
        const string FROM_DATE = "From";
        const string TO_DATE = "To";
        const string FIELDS = "Fields";
        const string LOCALITIES = "Localities";

        protected List<string> localities;
        protected List<string> fields;
        protected Dictionary<string, string> mappings;

        private string check;

        public string Check { get { return check; } set { check = value; } }

        public LocalityQuerySetupPanel()
        {
            InitializeComponent();
            InitialiseQuerySetupGUI();
        }

        private void InitialiseQuerySetupGUI()
        {
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
        /// Overloaded constructor for deserialization of object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public LocalityQuerySetupPanel(SerializationInfo info, StreamingContext ctxt)
        {

            InitializeComponent();
            InitialiseQuerySetupGUI();

            this.txtFile.Text = (string)info.GetValue(DB_PATH, typeof(string));
            this.check = (string)info.GetValue(DB_PATH, typeof(string));
            this.txtTable.Text = info.GetString(SOURCE_TABLE);
            this.FromDate = info.GetDateTime(FROM_DATE);
            this.ToDate = info.GetDateTime(TO_DATE);
            
            //not storing fields and localities a the moment.
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

                return settings;
                
            }
            set
            {
                this.DatabasePath = value.DatabasePath;
                this.SourceTable = value.SourceTable;
                this.ToDate = value.ToDate;
                this.FromDate = value.FromDate;
                this.DateFieldName = value.DateFieldName;
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



        /// <summary>
        /// Handles serialization of object.  Only stores ILocalityQuerySetup properties
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(DB_PATH, this.DatabasePath);
            info.AddValue(SOURCE_TABLE, this.SourceTable);
            info.AddValue(FROM_DATE, this.FromDate);
            info.AddValue(TO_DATE, this.ToDate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.Check);
        }

        
    }
}
