using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using LocalSearch;

namespace HomeVisitTravelAnalyser.Analysis
{
    public class RandomTourRandomBase : IDataTableRowSampler
    {

        protected DataTableRandomRowSampler sampler;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="seed">Random seed so that sample order be replicated</param>
        public RandomTourRandomBase(int seed)
        {
            this.sampler = new DataTableRandomRowSampler(seed);
        }


        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="data">Cases to sample from stored in a datatable</param>
        /// <param name="seed">Random seed so that sample order be replicated</param>
        public RandomTourRandomBase(DataTable data, int seed)
        {
            this.sampler = new DataTableRandomRowSampler(data, seed);
        }


        /// <summary>
        /// Sample a number of cases each time replacing the case in the sample pool
        /// </summary>
        /// <param name="sampleSize">The number of cases to sample</param>
        /// <returns>Datatable containing sample of cases</returns>
        public System.Data.DataTable SampleWithReplacement(int sampleSize)
        {
            return this.sampler.SampleWithReplacement(sampleSize + 1);
        }

        /// <summary>
        /// Sample a number of cases and DO NOT replacing the case in the sample pool
        /// </summary>
        /// <param name="sampleSize">The number of cases to sample</param>
        /// <returns>Datatable containing sample of cases</returns>
        public System.Data.DataTable SampleWithoutReplacement(int sampleSize)
        {
            return this.sampler.SampleWithoutReplacement(sampleSize + 1);
        }


        /// <summary>
        /// Set the sample that will be sampled from
        /// </summary>
        /// <param name="data">The datatable containing all cases</param>
        public void SetSamplePool(System.Data.DataTable data)
        {
            this.sampler.SetSamplePool(data);
        }
    }
}
