using SellerProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerProductService.BusinessLogicLayer.Contract
{
    public interface ISellerProductBL
    {
        bool AddSellerProductInfo(SellerProduct productSellerInfo);

        SellerProduct GetSellerProductInfo(int productID);

        bool DeleteProduct(int productId);

        List<BidDetails> GetAllBidsForProduct(int productID);
        
        List<SellerProduct> GetAllProducts();
    }
}
