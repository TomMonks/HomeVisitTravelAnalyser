using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseClasses;
using DatabaseClasses.MSAccess;
using DatabaseClasses.SQL;

namespace CommunityNurseTravelAnalyser
{
    public class LocalityVisitsByDayQuery
    {
        protected LocalityVisitsByDayQuery dayQuery;
        protected IDatabase database;
        protected ISelectStatement select;
        protected IFromClause from;

        public LocalityVisitsByDayQuery(IDatabase database, ISelectStatement select, IFromClause from)
        {
            this.database = database;
            this.select = select;
            this.from = from;
            
        }


    }
}
