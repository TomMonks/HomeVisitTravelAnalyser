using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using LocalSearch;
using DistanceFunctions;

namespace HomeVisitTravelAnalyser.Analysis
{
    public class RandomTourWithCentroidBase : IDataTableRowSampler
    {
        protected DataTableRandomRowSampler sampler;
        protected DataTable data;
        protected Coordinate centroid;
        protected EastingNorthingColumnIndexer indexer;



        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="seed">Random seed for replicability</param>
        /// <param name="indexer">Easting and northing column indexes for datatables</param>
        public RandomTourWithCentroidBase(int seed, EastingNorthingColumnIndexer indexer)
        {
            this.sampler = new DataTableRandomRowSampler(seed);
            this.indexer = indexer;

        } 

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="data">Sample pool of cases in a datatable</param>
        /// <param name="seed">Random seed for replicability</param>
        /// <param name="indexer">Easting and northing column indexes for datatables</param>
        public RandomTourWithCentroidBase(DataTable data, int seed, EastingNorthingColumnIndexer indexer)
        {
            this.data = data;
            this.sampler = new DataTableRandomRowSampler(data, seed);
            this.indexer = indexer;
            CalculateCentroid(data, indexer);
        }

        private void CalculateCentroid(DataTable data, EastingNorthingColumnIndexer indexer)
        {
            var gen = new GroupCentroid(data, indexer);
            centroid = gen.GetCentreCoordinates();
        }


        /// <summary>
        /// Sample the cases and replace each value after sample
        /// </summary>
        /// <param name="sampleSize">Number of rows to sample</param>
        /// <returns>Datatable representing a random sample</returns>
        public DataTable SampleWithReplacement(int sampleSize)
        {
            DataTable cases = sampler.SampleWithReplacement(sampleSize);
            int pos = 0;

            var firstRow = cases.NewRow();
            firstRow[indexer.EastingIndex] = centroid.Easting;
            firstRow[indexer.NorthingIndex] = centroid.Northing;

            cases.Rows.InsertAt(firstRow, pos);

            var lastRow = cases.NewRow();
            lastRow[indexer.EastingIndex] = centroid.Easting;
            lastRow[indexer.NorthingIndex] = centroid.Northing;

            cases.Rows.Add(lastRow);

            return cases;
        }




        /// <summary>
        /// Sample the cases and DO NOT replace each value after sample
        /// </summary>
        /// <param name="sampleSize">Number of rows to sample</param>
        /// <returns>Datatable representing a random sample</returns>
        public DataTable SampleWithoutReplacement(int sampleSize)
        {
            DataTable cases = sampler.SampleWithoutReplacement(sampleSize);
            int pos = 0;

            var firstRow = cases.NewRow();
            firstRow[indexer.EastingIndex] = centroid.Easting;
            firstRow[indexer.NorthingIndex] = centroid.Northing;

            cases.Rows.InsertAt(firstRow, pos);

            var lastRow = cases.NewRow();
            lastRow[indexer.EastingIndex] = centroid.Easting;
            lastRow[indexer.NorthingIndex] = centroid.Northing;

            cases.Rows.Add(lastRow);

            return cases;
        }



        /// <summary>
        /// Set the sample pool of cases.
        /// </summary>
        /// <param name="data">The data table containing the sample pool</param>
        public void SetSamplePool(DataTable data)
        {
            this.data = data;
            this.sampler.SetSamplePool(data);
            CalculateCentroid(data, indexer);
        }
    }
}
