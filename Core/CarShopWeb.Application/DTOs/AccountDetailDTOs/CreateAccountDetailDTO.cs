using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.DTOs.AccountDetailDTOs
{
    public class CreateAccountDetailDTO
    {
        public int CustomerID { get; set; }
        public string Code { get; set; }
        public decimal Money { get; set; }
    }
}
