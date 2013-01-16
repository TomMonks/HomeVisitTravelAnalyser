using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace HomeVisitTravelAnalyser.Query
{
    public class VisitsByDayLINQQuery
    {

        protected DataTable data;

        public DateTime Date { get; set; }

        public VisitsByDayLINQQuery(DataTable data)
        {
            this.data = data;
        }


        public DataTable Execute()
        {

            DataTable output;

            var results = from patients in this.data.AsEnumerable()
                          where patients.Field<DateTime>("Date") == this.Date
                          select patients;

            try
            {
                output = results.CopyToDataTable();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No data for {0}", this.Date);
                output = null;
            }

            return output;
            
        }

    }
}
