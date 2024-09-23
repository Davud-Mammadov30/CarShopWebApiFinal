using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class CarBrand : BaseEntity
    {
        public string Name { get; set; } // "Mercedes", "BMW", etc.
        public IList<CarModel> CarModels { get; set; } // Relationship with CarModel
    }
}
