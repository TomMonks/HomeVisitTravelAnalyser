using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DistanceFunctions;

namespace HomeVisitTravelAnalyser.Analysis
{
    /// <summary>
    /// Argument class for parametering RandomTourObjects
    /// </summary>
    public class RandomTourArguments
    {
        protected int seed;

        public Dictionary<string, DataTable> DataSets { get; set; }
        public EastingNorthingColumnIndexer Indexer { get; set; }

        public int Seed { get { return this.seed; } set { this.seed = value; } }

        public RandomTourArguments(int seed)
        {
            this.seed = seed;
            this.DataSets = new Dictionary<string, DataTable>();
        }
    }
}
