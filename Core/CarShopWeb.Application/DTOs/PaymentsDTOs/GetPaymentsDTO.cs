using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.DTOs.PaymentsDTOs
{
    public class GetPaymentsDTO
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
