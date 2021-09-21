using Buyer_BidProduct_Service.BusinessLogicLayer.Contracts;
using Buyer_BidProduct_Service.DBServiceLayer;
using Buyer_BidProduct_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buyer_BidProduct_Service.BusinessLogicLayer.Implementations
{
    public class BuyerBidProductService_BL : IBuyerBidProductService_BL
    {
        private readonly BuyerService _buyerService;
        public BuyerBidProductService_BL(BuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        public bool AddBuyersBidDetails(BuyerBidDetails buyer)
        {
            bool isSuccess = false;
            bool validationCheckPassed = false;

            try
            {
                if (ValidateRequestBody(buyer))
                {
                    Product product = _buyerService.GetProductDetails(buyer.ProductID);

                    if (ValidateProductForExistence(buyer.ProductID))
                    {
                        validationCheckPassed = true;
                    }

                    if (validationCheckPassed && !ValidateProductBidDate(buyer.ProductID))
                    {
                        validationCheckPassed = false;
                    }
                    if (validationCheckPassed && !ValidateDuplicateBid(buyer.ProductID, buyer.Email))
                    {
                        validationCheckPassed = false;
                    }

                    if (validationCheckPassed)
                    {
                        _buyerService.CreateBid(buyer);
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return isSuccess;
        }

        public BuyerBidDetails GetProductbyBuyerId(string emailId, int productID)
        {
            return _buyerService.GetProductbyBuyerId(emailId, productID).FirstOrDefault();
        }

        public bool UpdateBid(int productId, string emailId,long newBidAmount)
        {
            bool isValidRequest = true;
            bool isUpdateSuccessful = false;

            Product product = _buyerService.GetProductDetails(productId);

            if (DateTime.Now > Convert.ToDateTime(product.BidEndDate))
            {
                isValidRequest = false;
                return isValidRequest;
            }

            if (isValidRequest)
            {
                _buyerService.UpdateBid(productId,emailId, newBidAmount);
            }

            return isUpdateSuccessful;
        }

        private bool ValidateProductForExistence(int productID)
        {
            return _buyerService.GetProductCount(productID) > 0 ? true : false;

        }

        private bool ValidateRequestBody(BuyerBidDetails buyer)
        {
            bool isFNValid = false,
                isLNValid = false,
                isEmailValid = false,
                isPhoneValid = false;
            long phone;
            if (buyer != null)
            {
                if (!string.IsNullOrWhiteSpace(buyer.FirstName) && buyer.FirstName.Length >= 5
                    && buyer.FirstName.Length <= 30)
                {
                    isFNValid = true;
                }
                if (!string.IsNullOrWhiteSpace(buyer.LastName) && buyer.LastName.Length >= 3
                    && buyer.LastName.Length <= 25)
                {
                    isLNValid = true;
                }
                if (!string.IsNullOrWhiteSpace(buyer.Email) && Regex.IsMatch(buyer.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    isEmailValid = true;
                }
                if (!string.IsNullOrWhiteSpace(buyer.Phone) &&
                    long.TryParse(buyer.Phone, out phone) && buyer.Phone.Length == 10)
                {
                    isPhoneValid = true;
                }

            }
            return (isFNValid && isLNValid && isEmailValid && isPhoneValid);
        }

        private bool ValidateProductBidDate(int productID)
        {
            DateTime productBidEndDate = Convert.ToDateTime(_buyerService.GetProductDetails(productID).BidEndDate);

            return DateTime.Now > productBidEndDate ? false : true;
        }

        private bool ValidateDuplicateBid(int productID, string emailId)
        {
            return _buyerService.GetProductbyBuyerId(emailId, productID).Count() > 0 ? false : true;
        }
    }
}
