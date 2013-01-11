using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using DistanceFunctions;
using EasyDatabase.MSAccess;
using EasyDatabase.SQL;

using CommunityNurseTravelAnalyser.Query;

namespace CommunityNurseTravelAnalyser.Analysis
{

    /// <summary>
    /// Encapsulates the functionality to calculate the distribution of the average 
    /// distance that points are from the group centroid over a specified range of days
    /// </summary>
    public class AverageDailyDistanceCalculator
    {
              
        protected IDistanceCalculator calculator;
        protected DateTime from;
        protected DateTime to;
        protected DateRange period;
        protected VisitsByDayLINQQuery query;

        public AverageDailyDistanceCalculator(IDistanceCalculator calculator, DateRange period, VisitsByDayLINQQuery query)
        {

            this.calculator = calculator;
            this.period = period;
            this.query = query;
           
        }

        /// <summary>
        /// For each date in the specified period calculate and return the average distance from the group centroid
        /// </summary>
        /// <returns>List of average distances by day</returns>
        public List<double> GetAverageDistances()
        {
            var performance = new List<double>();

            var generator = new CentroidDistanceGenerator(new PythagoreanCalculator());

            foreach (DateTime day in EachDay(period))
            {
                performance.Add(DailyAverage(generator, day));
            }

            return performance;
        }

        /// <summary>
        /// Enumerate a DateRange struct
        /// </summary>
        /// <param name="range">The range of dates to enumerate</param>
        /// <returns>The current date in the sequence</returns>
        private IEnumerable<DateTime> EachDay(DateRange range)
        {
            for (var day = period.From.Date; day.Date <= period.To.Date; day = day.AddDays(1))
                yield return day;
        }

        /// <summary>
        /// Calculate the average distance from the group centroid on the particular day.
        /// </summary>
        /// <param name="generator">Object that generates the distance from the centroid</param>
        /// <param name="day">Date for calculation</param>
        /// <returns>Average distance from the group centroid for specified day</returns>
        private double DailyAverage(CentroidDistanceGenerator generator, DateTime day)
        {
            DataTable data;
            data = GetData(day);
            var average = generator.AverageDistance(data, new EastingNorthingColumnIndexer(0, 1));

            Console.WriteLine(string.Format("average dist: {0}", average));

            data.Clear();
            data.Dispose();
            data = null;
            return average;
        }


        /// <summary>
        /// Query the database for the records on the specified day
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private DataTable GetData(DateTime day)
        {
            DataTable data;
            query.Date = day;
            data = query.Execute();
            return data;
        }
    }
}
