﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeVisitTravelAnalyser.Query;

namespace HomeVisitTravelAnalyser.Analysis
{
    public class AnalysisMethodSetup
    {
        public ILocalityQuerySetup querySetup { get; set; }
        public IAnalysisCommand command { get; set; }

        public AnalysisMethodSetup() { }
    }
}
