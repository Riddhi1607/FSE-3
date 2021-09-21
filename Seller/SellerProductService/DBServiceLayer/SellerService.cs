using MongoDB.Bson;
using MongoDB.Driver;
using SellerProductService.DBServiceLayer.Models;
using SellerProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerProductService.DBServiceLayer
{
    public class SellerService
    {
        private readonly IMongoCollection<SellerProduct> _SellerProductCollection;
        private readonly IMongoCollection<BidDetails> _bidDetailsCollection;

        public SellerService(ISellerDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _SellerProductCollection = database.GetCollection<SellerProduct>(settings.ProductSellerCollectionName);
            _bidDetailsCollection = database.GetCollection<BidDetails>(settings.BidDetailsCollectionName);
        }

        public SellerProduct GetSellerProductInfo(int productID)
        {
            return _SellerProductCollection.Find<SellerProduct>(x => x.ProductId == productID).FirstOrDefault();
        }

        public bool CreateProduct(SellerProduct product)
        {
            bool isSuccess = false;

            try
            {
                _SellerProductCollection.InsertOne(product);
                isSuccess = true;
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public bool DeleteProduct(int productId)
        {
            bool isSuccess = false;

            try
            {
                _SellerProductCollection.DeleteOne(x => x.ProductId == productId);
                isSuccess = true;
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public long GetBidsForProduct(int productID)
        {
            return _bidDetailsCollection.Find(x => x.ProductId == productID).CountDocuments();
        }
        public List<SellerProduct> GetAllProducts()
        {
            return _SellerProductCollection.Find(x => true).ToList();
        }
        public List<BidDetails> GetBidsDetailsForProduct(int productID)
        {
            List<BidDetails> result = null;
            try
            {
                //result = _SellerProductCollection.Aggregate()
                //       .Match(x => x.ProductId == productID)
                //     .Lookup("Bid_Details", "_id", "ProductId", "list_of_bids")
                //     .As<BsonDocument>()
                //     .ToList().FirstOrDefault().ToJson();
                result = _bidDetailsCollection.Find<BidDetails>(z => z.ProductId == productID).SortByDescending(x=>x.BuyersBidAmount).ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }


    }
}
