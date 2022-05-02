using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyUniverseData.Models
{
    public partial class ShippingRate
    {
        public string CCountryId { get; set; }
        public string CModeId { get; set; }
        public decimal MRatePerPound { get; set; }

        public virtual Country CCountry { get; set; }
        public virtual ShippingMode CMode { get; set; }
    }
}
