using System;
namespace HomeVisitTravelAnalyser.Analysis
{

    public enum BaseSetup
    {
        LocalityCentroid = 0,
        RandomWithinLocality = 1
    };

    public enum SearchMethod
    { 
        OrdinaryDecent = 0,
        SteepestDecent = 1,
        BruteForce = 3
    };

    public interface ITSPOptions
    {
        bool OrdinaryDecent { get; }
        int Sample { get; }
        int Seed { get; }
        int TourLength { get; }
        BaseSetup TourBaseSetup { get; }
        SearchMethod TourSearchMethod { get; }

    }
}
