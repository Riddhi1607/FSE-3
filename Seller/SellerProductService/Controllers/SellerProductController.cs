using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SellerProductService.BusinessLogicLayer.Contract;
using SellerProductService.BusinessLogicLayer.Implementation;
using SellerProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerProductController : ControllerBase
    {
        private ISellerProductBL _sellerProductBL;
        public SellerProductController(ISellerProductBL sellerProductBL)
        {
            _sellerProductBL = sellerProductBL;
        }

        [HttpGet("GetSellerProductInfo/{productID}", Name = "GetSellerProductInfo")]
        public ActionResult<SellerProduct> GetSellerProductInfo(int productID)
        {
            if (_sellerProductBL.GetSellerProductInfo(productID) != null)
            {
                return Ok(_sellerProductBL.GetSellerProductInfo(productID));
            }
            return NotFound();
        }

        [HttpGet("GetAllProduct", Name = "GetAllProduct")]
        public ActionResult GetAllProduct()
        {
            var products = _sellerProductBL.GetAllProducts();
            if (products != null &&
                products.Count() > 0)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProduct(SellerProduct productSellerInfo)
        {
            if (_sellerProductBL.AddSellerProductInfo(productSellerInfo))
            {
                return StatusCode(201);
            }
            return StatusCode(500, "Some error occured while creating the Product");
        }

        [HttpDelete("{productID}")]
        public IActionResult DeleteProduct(int productID)
        {
            if (_sellerProductBL.GetSellerProductInfo(productID) == null)
            {
                return NotFound();
            }
            else if (_sellerProductBL.DeleteProduct(productID))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Some error occured while deleting the Product");
            }

        }

        [HttpGet("GetAllBidsForProduct/{productID}", Name = "GetAllBidsForProduct")]
        public ActionResult GetAllBidsForProduct(int productID)
        {
            var result = _sellerProductBL.GetAllBidsForProduct(productID);

            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }

            return StatusCode(500, "Some error occured while retrieving Bid Info for the Product");

        }
    }
}
