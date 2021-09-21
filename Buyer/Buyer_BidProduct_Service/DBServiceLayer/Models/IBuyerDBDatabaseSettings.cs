using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buyer_BidProduct_Service.DBServiceLayer.Models
{
    public interface IBuyerDBDatabaseSettings
    {
        string BuyersBidDetailsCollectionName { get; set; }

        public string ProductCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
