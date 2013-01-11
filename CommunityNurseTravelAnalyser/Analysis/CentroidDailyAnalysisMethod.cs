using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using EasyExcel;
using DistanceFunctions;
using Statistics.Descriptive;
using EasyDatabase.MSAccess;
using EasyDatabase.SQL;

using HomeVisitTravelAnalyser.Query;
using HomeVisitTravelAnalyser.Results;

namespace HomeVisitTravelAnalyser.Analysis
{
    public class CentroidDailyAnalysisMethod : IAnalysisCommand 
    {

        protected ILocalityQuerySetup querySetup;
        protected List<LocalityResult> results;

        protected const double FIFTH_PERCENTILE = 0.05;
        protected const double NINETYFIFTH_PERCENTILE = 0.95;
        protected const int DECIMAL_PLACES = 1;

        /// <summary>
        /// The locality results
        /// </summary>
        public List<LocalityResult> Result
        {
            get
            {
                return this.results;
            }
        }

        public CentroidDailyAnalysisMethod(ILocalityQuerySetup querySetup)
        {
            this.querySetup = querySetup;
            this.results = new List<LocalityResult>();
        }

        public void Execute()
        {

            foreach (var locality in querySetup.SelectedLocalities)
            {
                

                var calculator = CreateDistanceCalculator(locality);

                Console.WriteLine(string.Format("Calcultating daily distance from centroid for {0}", locality));
                List<double> distancesByDay = calculator.GetAverageDistances();

                RecordLocalityResults(locality, distancesByDay);

                distancesByDay.Clear();
                distancesByDay = null;

            }
            
        }


        public AverageDailyDistanceCalculator CreateDistanceCalculator(string locality)
        {
            return new AverageDailyDistanceCalculator(new PythagoreanCalculator(),
                new DateRange(querySetup.FromDate, querySetup.ToDate), ParameteriseQuery(locality));
        }

        private VisitsByDayLINQQuery ParameteriseQuery(string locality)
        {
            var data = GetData(locality);

            var query = new VisitsByDayLINQQuery(data);

            return query;
        }

        private DataTable GetData(string locality)
        {
            var db = new AccessDatabase(querySetup.DatabasePath);

            var factory = new VisitsByLocalityQuerySQLFactory(querySetup, locality);

            var builder = new StandardQueryBuilder(factory);
            Console.WriteLine("Retrieving data for {0}", locality);
            var data = db.ExecuteQuery(builder.BuildSQL());
            return data;
        }


        /// <summary>
        /// Create a LocalityResult object to store result for locality
        /// </summary>
        /// <param name="locality">Name of locality</param>
        /// <param name="tours">Length of n sampled tours</param>
        private void RecordLocalityResults(string locality, List<double> days)
        {
            BasicStatistics stats = new BasicStatistics(days);
            var CI = new ConfidenceIntervalStandardNormal(stats);

            var localityResult = new LocalityResult()
            {
                Locality = locality,
                Mean = Math.Round(stats.Mean, DECIMAL_PLACES),
                LCI = Math.Round(CI.LowerBound, DECIMAL_PLACES),
                UCI = Math.Round(CI.UpperBound, DECIMAL_PLACES),
                FifthPercentile = Math.Round(stats.Percentile(FIFTH_PERCENTILE), DECIMAL_PLACES),
                NinetyFifthPercentile = Math.Round(stats.Percentile(NINETYFIFTH_PERCENTILE), DECIMAL_PLACES)
            };

            results.Add(localityResult);
        }

    }
}
