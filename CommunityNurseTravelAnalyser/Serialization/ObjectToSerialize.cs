using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using HomeVisitTravelAnalyser.Query;
using HomeVisitTravelAnalyser.UI;

namespace HomeVisitTravelAnalyser.Serialization
{
    /// <summary>
    /// Holds reference to all of the objects that will serialised in the program
    /// </summary>
    [Serializable()]
    public class ObjectToSerialize : ISerializable
    {
        List<UserQuerySettings> queries;

        public List<UserQuerySettings> Queries
        {
            get { return this.queries; }
            set { this.queries = value; }
        }

        public ObjectToSerialize()
        {
            this.queries = new List<UserQuerySettings>();
        }

        public ObjectToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            this.queries = (List<UserQuerySettings>)info.GetValue("Queries", typeof(List<UserQuerySettings>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Queries", this.Queries);
        }
    }
}
