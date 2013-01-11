using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeVisitTravelAnalyser
{
    public delegate void BackgroundEventHandler(object sender, BackgroundEventArgs args);
    
    public class BackgroundEventArgs : EventArgs
    {
        public string Message { get; set; }

    }

    
}
