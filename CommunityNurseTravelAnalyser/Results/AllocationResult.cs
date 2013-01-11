using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeVisitTravelAnalyser.Results
{

    /// <summary>
    /// The results of an allocation strategy 
    /// e.g patients allocted by home postcode 
    /// e.g.patient allocated by GP postcode
    /// </summary>
    public class AllocationResult
    {
        public string AllocationName { get; set; }

        /// <summary>
        /// Overall mean distance in the allocation
        /// </summary>
        public double Mean { get; set; }

        /// <summary>
        /// Lower bound of the 95% confidence interval of 
        /// the mean 
        /// </summary>
        public double LCI { get; set; }

        /// <summary>
        /// Upper bound of the 95% confidence interval of 
        /// the mean 
        /// </summary>
        public double UCI { get; set; }

        public AllocationResult(){}
    }
}
