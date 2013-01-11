using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using DatabaseClasses;
using DatabaseClasses.SQL;
using DatabaseClasses.MSAccess;


namespace CommunityNurseTravelAnalyser
{
    /// <summary>
    /// Returns visits on a specific date
    /// </summary>
    public class VistsByDayQuery2 : IQuery 
    {
        protected const string US_DATE_FORMAT = "MM/dd/yyyy";
        protected const string DATE_MISSING_ERROR = "Query requries a specific date; please specify.";

        protected IDatabase db;
        protected QueryBuilder builder;
        protected DateClause clause;

        public DateTime Date { get; set; }

        public VistsByDayQuery2(IDatabase db, QueryBuilder builder, DateClause clause)
        {
            this.db = db;
            this.builder = builder;
            this.clause = clause;
        }

        /// <summary>
        /// Executes query against specific date.
        /// </summary>
        /// <returns>Data stored in a DataTable object</returns>
        public DataTable Execute()
        {

            try
            {
                clause.Date = this.Date.ToString(US_DATE_FORMAT);

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(DATE_MISSING_ERROR);
            }

            return db.ExecuteQuery(this.builder.BuildSQL());
        }
    }
    
}
