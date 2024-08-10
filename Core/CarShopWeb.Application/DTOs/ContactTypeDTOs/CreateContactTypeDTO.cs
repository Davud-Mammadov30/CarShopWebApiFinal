using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.DTOs.ContactTypeDTOs
{
    public class CreateContactTypeDTO
    {
        public int CustomerID { get; set; }
        public string? Number { get; set; }
        public string? WhatsAppNumber { get; set; }
        public string? Email { get; set; }
    }
}
