using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using LocalSearch;
using HomeVisitTravelAnalyser.Query;
using DistanceFunctions;
using HomeVisitTravelAnalyser.Results;
using Statistics.Descriptive;

using EasyDatabase.MSAccess;
using EasyDatabase.SQL;

namespace HomeVisitTravelAnalyser.Analysis
{
    public class TravelingSalesmanAnalyser : IAnalysisCommand
    {
        protected const double FIFTH_PERCENTILE = 0.05;
        protected const double NINETYFIFTH_PERCENTILE = 0.95;
        protected const int DECIMAL_PLACES = 1;
        protected const string LOCALITY_IDENTIFER = "Locality";

        protected DataTableRandomRowSampler rnd;
        protected ILocalityQuerySetup querySetup;
        protected ITSPOptions options;
        protected List<LocalityResult> resultsByLocality;
        protected AllocationResult allocationResult;
        protected List<double> allTourLengths;
        protected IDataTableRowSampler sampler;

        protected ISamplePoolPrimer samplePrimer;

        

        /// <summary>
        /// The locality results
        /// </summary>
        public List<LocalityResult> ResultsByLocality
        {
            get
            {
                return this.resultsByLocality;
            }
        }

        public AllocationResult Results
        {
            get
            {
                return this.allocationResult;
            }
        }


        public TravelingSalesmanAnalyser(ILocalityQuerySetup querySetup, ITSPOptions options)
        {
            this.querySetup = querySetup;
            this.options = options;
            this.resultsByLocality = new List<LocalityResult>();
            this.allocationResult = new AllocationResult();
            this.allTourLengths = new List<double>();
        }


       
        public void Execute()
        {

            var initialCasesSampler = CreateRowSampler();
                        
            foreach (var locality in querySetup.SelectedLocalities)
            {

                Console.WriteLine(string.Format("Analysing locality: {0}", locality));
                
                var data = GetData(locality);
                samplePrimer.PrimeSamplePool(CreateSamplePoolArguments(locality, data));

                var localityTourLengths = new List<double>();

                for (int i = 1; i <= this.options.Sample; i++)
                {
                    var initialCases = initialCasesSampler.SampleWithoutReplacement(options.TourLength);

                    localityTourLengths.Add(Solve(CreateObjectiveFunction(initialCases), CreateInitialSolution()));

                    Console.WriteLine(string.Format("Tour length {0}: {1}", i, Math.Round(localityTourLengths[localityTourLengths.Count - 1], 1)));
                }

                RecordLocalityResults(locality, localityTourLengths);

                localityTourLengths.ForEach(x => allTourLengths.Add(x));

                data.Clear();
                data = null;

            }

            RecordAllocationResult();

        }

        

        private static SamplePoolPrimerArguments CreateSamplePoolArguments(string locality, DataTable data)
        {
            var args = new SamplePoolPrimerArguments() { Data = data };
            args.StringArguments.Add(LOCALITY_IDENTIFER, locality);
            return args;
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


        /// <summary>
        /// Queries the database for all hub data
        /// </summary>
        /// <returns></returns>
        private DataTable GetHubData()
        {
            var db = new AccessDatabase(this.querySetup.DatabasePath);

            var factory = new LocalityHubsQuerySQLFactory(this.querySetup);

            var builder = new StandardQueryBuilder(factory);

            var data = db.ExecuteQuery(builder.BuildSQL());

            return data;
        }


        /// <summary>
        /// For a tour of size n with the same start and end point creates a initial tour list in the form 0,1,2,3,4,5,...n, 0
        /// Where 0 is the start and end point.
        /// </summary>
        /// <returns></returns>
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
                
                var sampler = new RandomTourWithCentroidBase(this.options.Seed, new EastingNorthingColumnIndexer(0, 1));
                samplePrimer = new StandardSamplePoolPrimer(sampler);

                return sampler;
                
            }
            else if (options.TourBaseSetup == BaseSetup.RandomWithinLocality)
            {
                var sampler = new RandomTourRandomBase(this.options.Seed);
                samplePrimer = new StandardSamplePoolPrimer(sampler);
                return sampler;
            }
            else
            {

                var args = new RandomTourArguments(this.options.Seed) { Indexer = new EastingNorthingColumnIndexer(0, 1) };
                args.DataSets.Add("hub", GetHubData());

                var sampler = new RandomTourWithSpecifiedBase(args);
                samplePrimer = new SamplePoolPrimerSpecifiedBase(sampler, GetHubData());
                return sampler;
              
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

            resultsByLocality.Add(localityResult);
        }


        private void RecordAllocationResult()
        {
            BasicStatistics stats = new BasicStatistics(this.allTourLengths);
            var CI = new ConfidenceIntervalStandardNormal(stats);

            this.allocationResult = new AllocationResult()
            {
                Mean = stats.Mean,
                LCI = CI.LowerBound,
                UCI = CI.UpperBound,
                Stats = stats,
            };
        }
    }
}
