using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityNurseTravelAnalyser.Results
{
    public class ResultsContainer
    {
        protected List<LocalityResult> home;
        protected List<LocalityResult> gp;
        
        public string Name { get; set; }
        public string PageName { get; set; }

        public List<LocalityResult> Home { get { return this.home; } }
        public List<LocalityResult> GP { get { return this.gp; } }
        
        public ResultsContainer()
        {
            home = new List<LocalityResult>();
            gp = new List<LocalityResult>();
        }
    }
}
