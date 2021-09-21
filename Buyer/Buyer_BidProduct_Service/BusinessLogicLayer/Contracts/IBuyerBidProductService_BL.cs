using Buyer_BidProduct_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buyer_BidProduct_Service.BusinessLogicLayer.Contracts
{
    public interface IBuyerBidProductService_BL
    {
        bool AddBuyersBidDetails(BuyerBidDetails buyer);

        BuyerBidDetails GetProductbyBuyerId(string emailId, int productID);

        bool UpdateBid(int productId, string emailId, long newBidAmount);
    }
}
