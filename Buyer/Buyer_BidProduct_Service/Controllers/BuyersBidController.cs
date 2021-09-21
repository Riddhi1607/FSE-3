using Buyer_BidProduct_Service.BusinessLogicLayer.Contracts;
using Buyer_BidProduct_Service.DBServiceLayer;
using Buyer_BidProduct_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Buyer_BidProduct_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyersBidController : ControllerBase
    {
        private readonly IBuyerBidProductService_BL _buyerBL;

        public BuyersBidController(IBuyerBidProductService_BL buyerBL)
        {
            _buyerBL = buyerBL;
        }

        //[HttpGet]
        //public ActionResult<List<BuyerBidDetails>> Get() =>
        //    _buyerService.Get();

        [HttpGet("{buyerEmail}/{productID}", Name = "GetSingleBuyerProductPair")]
        public ActionResult<BuyerBidDetails> GetBidByBuyers(string buyerEmail, int productID)
        {
            var book = _buyerBL.GetProductbyBuyerId(buyerEmail, productID);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public IActionResult CreateBid(BuyerBidDetails buyer)
        {
            bool isSuccess = _buyerBL.AddBuyersBidDetails(buyer);

            if (isSuccess)
            {
                return CreatedAtRoute("GetSingleBuyerProductPair", new { buyerID = buyer.Email, productID = buyer.ProductID }, buyer);
            }
            else
            {
                return StatusCode(500);
            }

        }

        [HttpPut("{productId}/{buyerEmailId}/{newBidAmount}")]
        public IActionResult UpdateBid(int productId, string buyerEmailId, long newBidAmount)
        {
            var bids = _buyerBL.GetProductbyBuyerId(buyerEmailId, productId);

            if (bids == null)
            {
                return NotFound();
            }
            if (_buyerBL.UpdateBid(productId, buyerEmailId, newBidAmount))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(500);
            }

        }

    }
}
