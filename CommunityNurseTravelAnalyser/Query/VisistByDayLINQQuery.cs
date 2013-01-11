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
                       
            var results = from patients in this.data.AsEnumerable()
                          where patients.Field<DateTime>("Date") == this.Date
                          select patients;
            
            DataTable output = results.CopyToDataTable();

            return output;
            
        }

    }
}
