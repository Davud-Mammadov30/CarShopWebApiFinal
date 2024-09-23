using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class CarModel : BaseEntity
    {
        public int CarBrandID { get; set; }
        public CarBrand CarBrand { get; set; } // Foreign key to CarBrand
        public string Name { get; set; } // "S-Class", "3 Series", etc.
        public IList<Cars> Cars { get; set; } // Relationship with Cars
    }
}
