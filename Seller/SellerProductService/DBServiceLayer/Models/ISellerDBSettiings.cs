using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerProductService.DBServiceLayer.Models
{
    public interface ISellerDBSettings
    {
        string BidDetailsCollectionName { get; set; }
        string ProductSellerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
