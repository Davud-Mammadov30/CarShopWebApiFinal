using CarShopWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.DTOs.CarsDTOs
{
    public class GetCarsDTO
    {
        public int Id { get; set; }
        public int CarModelID { get; set; }
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
        public DateTime DateAdded { get; set; }
        public int HorsePower { get; set; }
        public string? Engine { get; set; }
        public int EngineCylinder { get; set; }
        public decimal EngineLiter { get; set; }
        public int Torque { get; set; }
    }
}
