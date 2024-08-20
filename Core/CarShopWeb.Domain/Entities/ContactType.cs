using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class ContactType : BaseEntity
    {
        public int CustomerID { get; set; }
        public string? Number { get; set; }
        public string? WhatsAppNumber { get; set; }
        public string? Email { get; set; }
        public Customers? Customers { get; set; }
    }
}
