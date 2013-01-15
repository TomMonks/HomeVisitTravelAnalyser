using System;
using System.Data;
using System.Collections.Generic;

namespace HomeVisitTravelAnalyser.Analysis
{

    public class SamplePoolPrimerArguments
    {
        public DataTable Data { get; set; }
        public Dictionary<string, string> StringArguments { get; set; }

        public SamplePoolPrimerArguments() 
        {
            this.StringArguments = new Dictionary<string, string>();
        }
    }

    public interface ISamplePoolPrimer
    {
        void PrimeSamplePool(SamplePoolPrimerArguments args);
    }
}
