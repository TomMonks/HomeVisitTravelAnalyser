using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using LocalSearch;
using CommunityNurseTravelAnalyser.Query;
using DistanceFunctions;
using CommunityNurseTravelAnalyser.Results;
using Statistics.Descriptive;

using EasyDatabase.MSAccess;
using EasyDatabase.SQL;

namespace CommunityNurseTravelAnalyser.Analysis
{
    public class TravelingSalesmanAnalyser : IAnalysisCommand
    {
        protected const double FIFTH_PERCENTILE = 0.05;
        protected const double NINETYFIFTH_PERCENTILE = 0.95;
        protected const int DECIMAL_PLACES = 1;

        protected DataTableRandomRowSampler rnd;
        protected ILocalityQuerySetup querySetup;
        protected ITSPOptions options;
        protected List<LocalityResult> results;
        protected IDataTableRowSampler sampler;

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


        public TravelingSalesmanAnalyser(ILocalityQuerySetup querySetup, ITSPOptions options)
        {
            this.querySetup = querySetup;
            this.options = options;
            this.results = new List<LocalityResult>();
        }


       
        public void Execute()
        {

            var initialCasesSampler = CreateRowSampler();

            

            foreach (var locality in querySetup.SelectedLocalities)
            {

                Console.WriteLine(string.Format("Analysing locality: {0}", locality));
                
                var data = GetData(locality);
                initialCasesSampler.SetSamplePool(data);

                var tourLengths = new List<double>();

                for (int i = 1; i <= this.options.Sample; i++)
                {
                    var initialCases = initialCasesSampler.SampleWithoutReplacement(options.TourLength);

                    tourLengths.Add(Solve(CreateObjectiveFunction(initialCases), CreateInitialSolution()));

                    Console.WriteLine(string.Format("Tour length {0}: {1}", i, Math.Round(tourLengths[tourLengths.Count - 1], 1)));
                }

                RecordLocalityResults(locality, tourLengths);

                data.Clear();
                data = null;

            }

        }


        /// <summary>
        /// Querys the database
        /// </summary>
        /// <param name="locality"></param>
        /// <returns></returns>
        private DataTable GetData(string locality)
        {
            var db = new AccessDatabase(this.querySetup.DatabasePath);

            var factory = new VisitsByLocalityQuerySQLFactory(this.querySetup, locality);

            var builder = new StandardQueryBuilder(factory);

            var data = db.ExecuteQuery(builder.BuildSQL());

            return data;
        }



        private List<int> CreateInitialSolution()
        {
            List<int> initialSolution = Enumerable.Range(0, options.TourLength + 1).ToList<int>();
            initialSolution.Add(0);
            return initialSolution;
        }


        /// <summary>
        /// TO BE encapsulated elsewhere....
        /// </summary>
        /// <param name="objective"></param>
        /// <param name="initialSolution"></param>
        /// <returns></returns>
        private ILocalSearchMethod CreateLocalSearchMethod(IObjectiveFunction objective, List<int> initialSolution)
        {
            //if (this.options.OrdinaryDecent)
            //{
            //    return new OrdinaryDecent(objective, initialSolution);
            //}
            //else
            //{
            //    return new SteepestDecent(objective, initialSolution);
            //}

            if (this.options.TourSearchMethod == SearchMethod.OrdinaryDecent)
            {
                return new OrdinaryDecent(objective, initialSolution);
            }
            else if (this.options.TourSearchMethod == SearchMethod.SteepestDecent)
            {
                return new SteepestDecent(objective, initialSolution);
            }
            else
            {
                return new BruteForceSearch(objective, initialSolution);
            }

        }


        private IDataTableRowSampler CreateRowSampler()
        {
            if (options.TourBaseSetup == BaseSetup.LocalityCentroid)
            {
                return new RandomTourWithCentroidBase(options.Seed, new EastingNorthingColumnIndexer(0, 1));
            }
            else
            {
                return new RandomTourRandomBase(this.options.Seed);
            }
        }


        private IObjectiveFunction CreateObjectiveFunction(DataTable cases)
        {
            
            var gen = new MatrixGenerator(new PythagoreanCalculator());
            var matrix = gen.GenerateMatrix(cases, new EastingNorthingColumnIndexer(0, 1));
            var objective = new SimpleTourLengthCalculator(matrix);
            return objective;
        }


        /// <summary>
        /// Searchs for the optimal tour using a localsearch method 
        /// </summary>
        /// <param name="objective">The objective function</param>
        /// <param name="initialSolution">The initial tour</param>
        /// <returns></returns>
        protected double Solve(IObjectiveFunction objective, List<int> initialSolution)
        {
            var localSearch = CreateLocalSearchMethod(objective, initialSolution);
            localSearch.Solve();
            return localSearch.Cost;
        }


        /// <summary>
        /// Create a LocalityResult object to store result for locality
        /// </summary>
        /// <param name="locality">Name of locality</param>
        /// <param name="tours">Length of n sampled tours</param>
        private void RecordLocalityResults(string locality, List<double> tours)
        {
            BasicStatistics stats = new BasicStatistics(tours);
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
