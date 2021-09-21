using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buyer_BidProduct_Service.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int64)]
        public int ProductID { get; set; }

        [BsonElement("ShortDesc")]
        public string ShortDesc { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("BidEndDate")]
        public string BidEndDate { get; set; }
    }
}
