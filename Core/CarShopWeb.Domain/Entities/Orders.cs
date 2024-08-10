using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class Orders : BaseEntity
    {
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IList<OrderDetails>? OrderDetails { get; set; }
    }
}
