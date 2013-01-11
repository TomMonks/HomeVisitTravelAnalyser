using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using HomeVisitTravelAnalyser.Results;
using HomeVisitTravelAnalyser.Query;

using EasyDatabase.MSAccess;
using EasyDatabase.SQL;

using DistanceFunctions;

using Statistics.Descriptive;

namespace HomeVisitTravelAnalyser.Analysis
{
    public class CentroidAnalysisMethod : IAnalysisCommand 
    {
        protected ILocalityQuerySetup querySetup;
        protected List<LocalityResult> results;

        protected const double FIFTH_PERCENTILE = 0.05;
        protected const double NINETYFIFTH_PERCENTILE = 0.95;
        protected const int DECIMAL_PLACES = 1;

        public CentroidAnalysisMethod(ILocalityQuerySetup querySetup)
        {
            this.querySetup = querySetup;
            this.results = new List<LocalityResult>();
        }

        public List<Results.LocalityResult> Result
        {
            get { return this.results; }
        }

        public void Execute()
        {
          
            foreach (var locality in querySetup.SelectedLocalities)
            {
                var gen = CreateDistanceCalculator();
                
                Console.WriteLine(string.Format("Calcultating average distance from centroid for {0}", locality));
                
                var localityResults = gen.GetIndividualDistances(GetData(locality), new EastingNorthingColumnIndexer(0, 1));

                RecordLocalityResults(locality, localityResults);
                
                localityResults.Clear();
                localityResults = null;
            }
        }

        protected CentroidDistanceGenerator CreateDistanceCalculator()
        {
            return new CentroidDistanceGenerator(new PythagoreanCalculator());

        }


        protected DataTable GetData(string locality)
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
        /// <param name="data">data points for locality</param>
        protected void RecordLocalityResults(string locality, List<double> data)
        {
            BasicStatistics stats = new BasicStatistics(data);
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
