using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeVisitTravelAnalyser
{
    public struct DateRange
    {
        private readonly DateTime from;
        private readonly DateTime to;

        public DateTime From { get { return this.from; } }
        public DateTime To { get { return this.to; } }

        public DateRange(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }

        public override string ToString()
        {
            return String.Format("{0} to {1}", from, to);
        }

        public override bool Equals(object obj)
        {
            DateRange test;

            try
            {
                test = (DateRange)obj;
            }
            catch (InvalidCastException)
            {
                return false;
            }

            if (this.From == test.From && this.To == test.To)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
