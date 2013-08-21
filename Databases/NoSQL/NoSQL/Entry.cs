using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace NoSQL
{
    public class Entry
    {
        public ObjectId _id { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
    }
}
