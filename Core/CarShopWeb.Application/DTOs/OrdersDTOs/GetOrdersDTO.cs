using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.DTOs.OrdersDTOs
{
    public class GetOrdersDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
