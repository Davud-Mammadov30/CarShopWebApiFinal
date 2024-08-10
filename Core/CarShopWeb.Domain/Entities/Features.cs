using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class Features : BaseEntity
    {
        public string? FutureType { get; set; }
        public string? FutureName { get; set; }
        public decimal AdditionalPrice { get; set; }
        public IList<CarFeatures>? CarFeatures { get; set; }
        public IList<OrderDetails>? OrderDetails { get; set; }
    }
}
