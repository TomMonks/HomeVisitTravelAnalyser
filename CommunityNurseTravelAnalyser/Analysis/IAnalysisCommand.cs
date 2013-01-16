using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeVisitTravelAnalyser.Results;

namespace HomeVisitTravelAnalyser.Analysis
{
    public interface IAnalysisCommand
    {
        
        List<LocalityResult> ResultsByLocality { get; }
        AllocationResult Results { get; }
        void Execute();
    }
}
