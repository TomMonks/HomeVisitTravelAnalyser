using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HomeVisitTravelAnalyser.Query
{
    [Serializable]
    public class UserQuerySettings : ILocalityQuerySetup, ISerializable
    {

        const string DB_PATH = "Path";
        const string SOURCE_TABLE = "Source";
        const string FROM_DATE = "From";
        const string TO_DATE = "To";
        const string FIELDS = "Fields";
        const string LOCALITIES = "Localities";
        const string DATE_FIELDNAME = "DateField";
        const string RECENT_FILES = "RecentFiles";


        public UserQuerySettings() { this.fields = new List<string>();}


        /// <summary>
        /// Overloaded constructor for deserialization of object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public UserQuerySettings(SerializationInfo info, StreamingContext ctxt)
        {

            this.DatabasePath = info.GetString(DB_PATH);
            this.SourceTable = info.GetString(SOURCE_TABLE);
            this.FromDate = info.GetDateTime(FROM_DATE);
            this.ToDate = info.GetDateTime(TO_DATE);
            this.DateFieldName = info.GetString(DATE_FIELDNAME);
            this.fields = new List<string>();

            this.recentFiles = (List<string>)info.GetValue(RECENT_FILES, typeof(List<string>));
            
            //not storing fields and localities a the moment.
        }


        protected List<string> localities;
        protected List<string> fields;
        protected Dictionary<string, string> mappings;
        protected List<string> recentFiles;
                

        /// <summary>
        /// The database path
        /// </summary>
        public string DatabasePath { get; set; }

        /// <summary>
        /// The source table to query
        /// </summary>
        public string SourceTable { get; set; }

        /// <summary>
        /// The name of the date field in the database
        /// </summary>
        public string DateFieldName { get; set; }

        /// <summary>
        /// Start date of query
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// End date of query
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// The fields selected
        /// </summary>
        public List<string> SelectedFields { get { return fields; } set { fields = value; } }

        /// <summary>
        /// Select field mappings.
        /// </summary>
        public Dictionary<string, string> FieldMappings { get; set; }

        /// <summary>
        /// The localities selected
        /// </summary>
        public List<string> SelectedLocalities { get { return new List<string>(); } }


        /// <summary>
        /// Recent database files for the query settings.
        /// </summary>
        public List<string> RecentFiles { get { return this.recentFiles; } set { this.recentFiles = value; } }

        

        public string HubSourceTable
        {
            get;
            set;
        }

        public List<string> HubSelectedFields
        {
            get;
            set;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(DB_PATH, this.DatabasePath);
            info.AddValue(SOURCE_TABLE, this.SourceTable);
            info.AddValue(FROM_DATE, this.FromDate);
            info.AddValue(TO_DATE, this.ToDate);
            info.AddValue(DATE_FIELDNAME, this.DateFieldName);
            info.AddValue(RECENT_FILES, this.recentFiles);
          
        }



    }
}
