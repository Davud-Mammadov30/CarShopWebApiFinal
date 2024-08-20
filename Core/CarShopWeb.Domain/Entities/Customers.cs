using CarShopWeb.Domain.Entities.Common;
using CarShopWeb.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class Customers : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? AppUserID { get; set; }
        public IList<AccountDetail>? AccountDetails { get; set; }
        public IList<ContactType>? ContactTypes { get; set; }
        public AppUser? AppUser { get; set; }
        public IList<Orders>? Orders { get; set; }
    }
}
