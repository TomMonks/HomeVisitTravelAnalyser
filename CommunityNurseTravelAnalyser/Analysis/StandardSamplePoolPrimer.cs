using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using LocalSearch;

namespace HomeVisitTravelAnalyser.Analysis
{
    public class StandardSamplePoolPrimer : HomeVisitTravelAnalyser.Analysis.ISamplePoolPrimer
    {
        protected IDataTableRowSampler sampler;

        public StandardSamplePoolPrimer(IDataTableRowSampler sampler)
        {
            this.sampler = sampler;
        }

        public void PrimeSamplePool(SamplePoolPrimerArguments args)
        {
            this.sampler.SetSamplePool(args.Data);
        }
    }
}
