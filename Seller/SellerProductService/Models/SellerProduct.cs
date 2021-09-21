using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerProductService.Models
{
    public class SellerProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int64)]
        public int ProductId { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [BsonElement("ProductShortDescription")]
        public string ProductShortDescription { get; set; }

        [BsonElement("ProductDetailedDescription")]
        public string ProductDetailedDescription { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("StartingBid")]
        public int StartingBid { get; set; }

        [BsonElement("BidEndDate")]
        public string BidEndDate { get; set; }

        [BsonElement("SellerFirstName")]
        public string SellerFirstName { get; set; }

        [BsonElement("SellerLastName")]
        public string SellerLastName { get; set; }

        [BsonElement("SellerAddress")]
        public string SellerAddress { get; set; }

        [BsonElement("SellerCity")]
        public string SellerCity { get; set; }

        [BsonElement("SellerState")]
        public string SellerState { get; set; }

        [BsonElement("SellerPin")]
        public string SellerPin { get; set; }

        [BsonElement("SellerPhone")]
        public string SellerPhone { get; set; }

        [BsonElement("SellerEmail")]
        public string SellerEmail { get; set; }
    }
}
