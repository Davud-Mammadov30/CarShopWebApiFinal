using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class AccountDetail : BaseEntity
    {
        public int CustomerID { get; set; }
        public string Code { get; set; }
        public decimal Money { get; set; }
        public Customers? Customers { get;}
    }
}
