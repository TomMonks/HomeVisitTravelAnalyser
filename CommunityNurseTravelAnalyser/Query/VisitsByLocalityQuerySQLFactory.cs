using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasyDatabase.SQL;

namespace HomeVisitTravelAnalyser.Query
{
    class VisitsByLocalityQuerySQLFactory : ISQLFactory 
    {
        private const string US_DATE_FORMAT = "MM/dd/yyyy";
        private const string DATE = "Date";
        private const string LOCALITY = "Locality";
        private const string EASTING = "Easting";
        
        private ILocalityQuerySetup setup;
        private string locality;

        public VisitsByLocalityQuerySQLFactory(ILocalityQuerySetup setup, string locality)
        {
            this.setup = setup;
            this.locality = locality;
        }


        public IFromClause CreateFrom()
        {
            return new SimpleFromClause(this.setup.SourceTable);
        }

        public List<IRestrictClause> CreateRestrictions()
        {

            var restrictions = new List<IRestrictClause>();
           
            var dateClause = new BetweenDatesClause(setup.FieldMappings[DATE]) { fromDate = this.setup.FromDate.ToString(US_DATE_FORMAT), toDate = this.setup.ToDate.ToString(US_DATE_FORMAT) };
            var localityClause = new StandardClause(setup.FieldMappings[LOCALITY]) { Operator = SQLOperator.Equals, Value = "'" + locality + "'" };
            var notNullClause = new NotNullClause(setup.FieldMappings[EASTING]);
            
            restrictions.Add(dateClause);
            restrictions.Add(localityClause);
            restrictions.Add(notNullClause);

            return restrictions;

        }

        public ISelectStatement CreateSelect()
        {
            var select = new BasicSelectStatement();

            foreach (string field in this.setup.SelectedFields)
            {
                select.AddField(field);
            }

            return select;
        }
    }
}
