using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buyer_BidProduct_Service.DBServiceLayer.Models
{
    public class BuyerDBDatabaseSettings:IBuyerDBDatabaseSettings
    {
        public string BuyersBidDetailsCollectionName { get; set; }

        public string ProductCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
