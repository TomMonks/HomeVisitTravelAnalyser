using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityNurseTravelAnalyser.Results;

namespace CommunityNurseTravelAnalyser.Analysis
{
    public interface IAnalysisCommand
    {
        
        List<LocalityResult> Result { get; }
        void Execute();
    }
}
