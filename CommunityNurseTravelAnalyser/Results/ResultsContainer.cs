using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Statistics.Descriptive;

namespace HomeVisitTravelAnalyser.Results
{
    public class ResultsContainer
    {
        protected List<LocalityResult> home;
        protected List<LocalityResult> gp;

        public string Name { get; set; }
        public string PageName { get; set; }

        public List<LocalityResult> HomeResultsByLocality { get { return this.home; } }
        public List<LocalityResult> GPResultsByLocality { get { return this.gp; } }

        public AllocationResult HomeAllocation { get; set; }
        public AllocationResult GPAllocation { get; set; }
                        
        public ResultsContainer()
        {
            home = new List<LocalityResult>();
            gp = new List<LocalityResult>();

            HomeAllocation = new AllocationResult();
            HomeAllocation = new AllocationResult();
        }
    }
}
