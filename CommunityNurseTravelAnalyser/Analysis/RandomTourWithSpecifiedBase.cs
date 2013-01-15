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
    /// <summary>
    /// Construct a random tour (sampled) with a specified base (start and end point).
    /// </summary>
    public class RandomTourWithSpecifiedBase : IDataTableRowSampler
    {
        protected DataTableRandomRowSampler sampler;
        protected DataTable data;
        protected Coordinate baseNode;
        protected EastingNorthingColumnIndexer indexer;


        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="seed">Random seed for replicability</param>
        /// <param name="indexer">Easting and northing column indexes for datatables</param>
        public RandomTourWithSpecifiedBase(RandomTourArguments args)
        {
            this.sampler = new DataTableRandomRowSampler(args.Seed);
            this.indexer = args.Indexer;

        } 

        

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="data">Sample pool of cases in a datatable</param>
        /// <param name="seed">Random seed for replicability</param>
        /// <param name="indexer">Easting and northing column indexes for datatables</param>
        public RandomTourWithSpecifiedBase(DataTable data, RandomTourArguments args)
        {
            this.data = data;
            this.sampler = new DataTableRandomRowSampler(data, args.Seed);
            this.indexer = args.Indexer;
        }


        public int LocalityID { get; set; }

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
            firstRow[indexer.EastingIndex] = baseNode.Easting;
            firstRow[indexer.NorthingIndex] = baseNode.Northing;

            cases.Rows.InsertAt(firstRow, pos);

            var lastRow = cases.NewRow();
            lastRow[indexer.EastingIndex] = baseNode.Easting;
            lastRow[indexer.NorthingIndex] = baseNode.Northing;

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
            firstRow[indexer.EastingIndex] = baseNode.Easting;
            firstRow[indexer.NorthingIndex] = baseNode.Northing;

            cases.Rows.InsertAt(firstRow, pos);

            var lastRow = cases.NewRow();
            lastRow[indexer.EastingIndex] = baseNode.Easting;
            lastRow[indexer.NorthingIndex] = baseNode.Northing;

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
        }

        public void SetBaseNode(Coordinate baseNode)
        {
            this.baseNode = baseNode;
        }
    }
}
