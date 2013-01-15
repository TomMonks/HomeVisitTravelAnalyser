using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeVisitTravelAnalyser.Analysis;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HomeVisitTravelAnalyser.Settings
{
    [Serializable]
    public class UserTSPSettings: ITSPOptions 
    {

        public int Sample
        {
            get { throw new NotImplementedException(); }
        }

        public int Seed
        {
            get { throw new NotImplementedException(); }
        }

        public int TourLength
        {
            get { throw new NotImplementedException(); }
        }

        public BaseSetup TourBaseSetup
        {
            get { throw new NotImplementedException(); }
        }

        public SearchMethod TourSearchMethod
        {
            get { throw new NotImplementedException(); }
        }
    }
}
