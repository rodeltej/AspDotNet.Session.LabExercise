using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyUniverseData.Models
{
    public partial class ShippingMode
    {
        public ShippingMode()
        {
            Orders = new HashSet<Order>();
            ShippingRates = new HashSet<ShippingRate>();
        }

        public string CModeId { get; set; }
        public string CMode { get; set; }
        public int? IMaxDelDays { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
    }
}
