using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasyDatabase.SQL;

namespace HomeVisitTravelAnalyser.Query
{
    public class LocalityHubsQuerySQLFactory : ISQLFactory
    {
        private const string US_DATE_FORMAT = "MM/dd/yyyy";
        private const string DATE = "Date";
        private const string LOCALITY = "Locality";
        private const string EASTING = "Easting";
        
        private ILocalityQuerySetup setup;
        

        public LocalityHubsQuerySQLFactory(ILocalityQuerySetup setup)
        {
            this.setup = setup;
           
        }

        public IFromClause CreateFrom()
        {
            return new SimpleFromClause(this.setup.HubSourceTable);
        }

        /// <summary>
        /// No restrictions apart from avoid null hubs
        /// </summary>
        /// <returns></returns>
        public List<IRestrictClause> CreateRestrictions()
        {

            var restrictions = new List<IRestrictClause>();

            var notNullClause = new NotNullClause(setup.FieldMappings[EASTING]);

            restrictions.Add(notNullClause);

            return restrictions;

        }

        public ISelectStatement CreateSelect()
        {
            var select = new BasicSelectStatement();

            foreach (string field in this.setup.HubSelectedFields)
            {
                select.AddField(field);
            }

            return select;
        }
    }
}
