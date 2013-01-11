using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeVisitTravelAnalyser.Query
{
    public interface ILocalityQuerySetup
    {
        /// <summary>
        /// The database path
        /// </summary>
        string DatabasePath { get; }

        /// <summary>
        /// The source table to query
        /// </summary>
        string SourceTable { get; }


        /// <summary>
        /// Start date of query
        /// </summary>
        DateTime FromDate { get; }

        /// <summary>
        /// End date of query
        /// </summary>
        DateTime ToDate { get; }

        /// <summary>
        /// The fields selected
        /// </summary>
        List<string> SelectedFields {get;}

        /// <summary>
        /// Select field mappings.
        /// </summary>
        Dictionary<string, string> FieldMappings { get; set; }

        /// <summary>
        /// The localities selected
        /// </summary>
        List<string> SelectedLocalities { get; }




 
 

    }
}
