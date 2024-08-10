using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class Cars : BaseEntity
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
        public DateTime DateAdded { get; set; }
        public int HorsePower { get; set; }
        public string? Engine { get; set; }
        public int EngineCylinder { get; set; }
        public decimal EngineLiter { get; set; }
        public int Torque { get; set; }
        public IList<CarFeatures>? CarFeatures { get; set; }

    }
}
