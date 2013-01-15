using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LocalSearch;
using DistanceFunctions;

namespace HomeVisitTravelAnalyser.Analysis
{

    /// <summary>
    /// Primes a random tour sampler to use a specified base.
    /// </summary>
    public class SamplePoolPrimerSpecifiedBase : ISamplePoolPrimer
    {
        protected RandomTourWithSpecifiedBase sampler;
        protected DataTable hubLocations;
        protected const string LOCALITY_FIELD_MAPPING = "Region";
        protected const string LOCALITY_IDENTIFER = "Locality";
        
        public SamplePoolPrimerSpecifiedBase(RandomTourWithSpecifiedBase sampler, DataTable hubLocations)
        {
            this.sampler = sampler;
            this.hubLocations = hubLocations;
        }

        public void PrimeSamplePool(SamplePoolPrimerArguments args)
        {
            this.sampler.SetSamplePool(args.Data);
            
            var hubDetails = GetHub(args);

            //assumes that only single row returned and that Nothing in is col 2 and easting in col 1.
            var baseNode = new Coordinate(Convert.ToInt32(hubDetails.Rows[0][2]), Convert.ToInt32(hubDetails.Rows[0][1]));

            this.sampler.SetBaseNode(baseNode);
      
        }


        /// <summary>
        /// Select a specific hub using the locality name.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private DataTable GetHub(SamplePoolPrimerArguments args)
        {

            DataTable output;

            var results = from hubs in this.hubLocations.AsEnumerable()
                          where hubs.Field<string>(LOCALITY_FIELD_MAPPING) == args.StringArguments[LOCALITY_IDENTIFER]
                          select hubs;

            try
            {
                output = results.CopyToDataTable();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No hub base found for {0}. Please check if there is a matching record in the database", args.StringArguments[LOCALITY_IDENTIFER]);
                output = new DataTable();
            }

            return output;
               
        }
    }
}
