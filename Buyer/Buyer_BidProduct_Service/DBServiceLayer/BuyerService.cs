using Buyer_BidProduct_Service.DBServiceLayer.Models;
using Buyer_BidProduct_Service.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buyer_BidProduct_Service.DBServiceLayer
{
    public class BuyerService
    {
        private readonly IMongoCollection<BuyerBidDetails> _buyersBidData;
        private readonly IMongoCollection<Product> _productData;

        public BuyerService(IBuyerDBDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _buyersBidData = database.GetCollection<BuyerBidDetails>(settings.BuyersBidDetailsCollectionName);
            _productData = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public List<BuyerBidDetails> GetAllBids() =>
            _buyersBidData.Find(b => true).ToList();

        public List<BuyerBidDetails> GetAllBidsForASpecificBuyers(string emailId) =>
            _buyersBidData.Find<BuyerBidDetails>(b => b.Email == emailId).ToList();

        public List<BuyerBidDetails> GetProductbyBuyerId(string emailId, int productID) =>
            _buyersBidData.Find<BuyerBidDetails>(b => b.Email == emailId && b.ProductID == productID).ToList();

        public bool CreateBid(BuyerBidDetails buyerData)
        {
            bool isSuccess = false;
            try
            {
                _buyersBidData.InsertOne(buyerData);
                isSuccess = true;
            }
            catch (Exception ex)
            {

            }

            return isSuccess;
        }

        public bool UpdateBid(int productID, string emailId, long newBidAmount)
        {
            bool isSuccess = false;
            try
            {
                var filter = Builders<BuyerBidDetails>.Filter.Eq("Email", emailId) &
                    Builders<BuyerBidDetails>.Filter.Eq("ProductID", productID);
                var update = Builders<BuyerBidDetails>.Update.Set("BidAmount", newBidAmount);
                _buyersBidData.UpdateOne(filter, update);
                isSuccess = true;
            }
            catch (Exception ex)
            {

            }

            return isSuccess;
        }

        public Product GetProductDetails(int productID)
        {
            return _productData.Find<Product>(c => c.ProductID == productID).FirstOrDefault();
        }

        public long GetProductCount(int productID)
        {
            return _productData.Find<Product>(c => c.ProductID == productID).CountDocuments();
        }


    }
}
