using CarShopWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Domain.Entities
{
    public class CarFeatures : BaseEntity
    {
        public int CarID { get; set; }
        public Cars? Cars { get; set; }
        public int FeatureID { get; set; }
        public Features? Features { get; set; }
    }
}
