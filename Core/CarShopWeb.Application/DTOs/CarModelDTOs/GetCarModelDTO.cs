using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.DTOs.CarModelDTOs
{
    public class GetCarModelDTO
    {
        public int Id { get; set;}
        public int CarBrandID { get; set; }
        public string Name { get; set; }
    }
}
