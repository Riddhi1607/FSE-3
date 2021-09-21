using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerProductService.Models
{
    public class BidDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("ProductId")]
        public int ProductId { get; set; }

        [BsonElement("Buyer_Email")]
        public string BuyerEmail { get; set; }

        [BsonElement("Buyer_First_Name")]
        public string BuyerFirstName { get; set; }

        [BsonElement("Buyer_Last_Name")]
        public string BuyerLastName { get; set; }

        [BsonElement("BidAmount")]
        public int BuyersBidAmount { get; set; }
    }
}
