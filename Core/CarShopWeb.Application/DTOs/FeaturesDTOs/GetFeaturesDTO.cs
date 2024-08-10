using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.DTOs.FeaturesDTOs
{
    public class GetFeaturesDTO
    {
        public int FeatureID { get; set; }
        public string? FutureType { get; set; }
        public string? FutureName { get; set; }
        public decimal AdditionalPrice { get; set; }
    }
}
