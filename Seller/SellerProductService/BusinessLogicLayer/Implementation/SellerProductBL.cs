using SellerProductService.BusinessLogicLayer.Contract;
using SellerProductService.DBServiceLayer;
using SellerProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SellerProductService.BusinessLogicLayer.Implementation
{
    public class SellerProductBL : ISellerProductBL
    {
        private readonly SellerService _sellerService;
        public SellerProductBL(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public bool AddSellerProductInfo(SellerProduct productSellerInfo)
        {
            if (CheckConstraints(productSellerInfo))
            {
                if (_sellerService.CreateProduct(productSellerInfo))
                {
                    return true;
                }
            }

            return false;
        }

        public bool DeleteProduct(int productId)
        {
            if (CheckConstraintsForDelete(productId))
            {
                if (_sellerService.DeleteProduct(productId))
                {
                    return true;
                }
            }

            return false;
        }

        public SellerProduct GetSellerProductInfo(int productID)
        {
            return _sellerService.GetSellerProductInfo(productID);
        }


        public List<BidDetails> GetAllBidsForProduct(int productID)
        {            
            return _sellerService.GetBidsDetailsForProduct(productID);            
        }

        public List<SellerProduct> GetAllProducts()
        {
            return _sellerService.GetAllProducts();
        }

        private bool CheckConstraintsForDelete(int productID)
        {
            bool isValid = false;

            long productCount = _sellerService.GetBidsForProduct(productID);
            SellerProduct productData = _sellerService.GetSellerProductInfo(productID);

            if (productCount > 0 && DateTime.Now < Convert.ToDateTime(productData.BidEndDate))
            {
                isValid = true;
            }

            return isValid;
        }

        private bool CheckConstraints(SellerProduct productSellerInfo)
        {
            bool isValid = false;
            if (productSellerInfo.Category.ToUpper() == "PAINTING" ||
               productSellerInfo.Category.ToUpper() == "SCULPTOR" ||
               productSellerInfo.Category.ToUpper() == "ORNAMENT")
            {
                isValid = true;
            }

            if (isValid && Convert.ToDateTime(productSellerInfo.BidEndDate) < DateTime.Now)
            {
                isValid = false;
            }

            return isValid && PerformValidaions(productSellerInfo);
        }

        private bool PerformValidaions(SellerProduct productSellerInfo)
        {
            bool isValid = false;
            long phone;

            if (!string.IsNullOrEmpty(productSellerInfo.ProductName)
                && productSellerInfo.ProductName.Length >= 5
                && productSellerInfo.ProductName.Length <= 30)
            {
                isValid = true;
            }
            if (isValid && !string.IsNullOrEmpty(productSellerInfo.SellerFirstName)
                && productSellerInfo.SellerFirstName.Length >= 5
                && productSellerInfo.SellerFirstName.Length <= 30)
            {
                isValid = false;
            }
            if (isValid && !string.IsNullOrEmpty(productSellerInfo.SellerLastName)
                && productSellerInfo.ProductName.Length >= 3
               && productSellerInfo.ProductName.Length <= 25)
            {
                isValid = false;
            }
            if (isValid && !string.IsNullOrWhiteSpace(productSellerInfo.SellerEmail)
                && Regex.IsMatch(productSellerInfo.SellerEmail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                isValid = false;
            }
            if (isValid && !string.IsNullOrWhiteSpace(productSellerInfo.SellerPhone) &&
                long.TryParse(productSellerInfo.SellerPhone, out phone) && productSellerInfo.SellerPhone.Length == 10)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
