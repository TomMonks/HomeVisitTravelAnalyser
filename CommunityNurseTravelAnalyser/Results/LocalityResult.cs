using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Statistics.Descriptive;


namespace HomeVisitTravelAnalyser.Results
{
    public class LocalityResult
    {
        public string Locality { get; set; }
        public double Mean { get; set; }
        public double LCI { get; set; }
        public double UCI { get; set; }
        public double FifthPercentile { get; set; }
        public double NinetyFifthPercentile { get; set; }

        public LocalityResult()
        {

        }
    }
}
