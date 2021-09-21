using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Buyer_BidProduct_Service.Models
{
    public class BuyerBidDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("State")]
        public string State { get; set; }

        [BsonElement("Pin")]
        public string Pin { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("ProductID")]
        public int ProductID { get; set; }

        [BsonElement("BidAmount")]
        public long BidAmount { get; set; }
    }
}
