using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyUniverseData.Models
{
    public partial class Shipment
    {
        public string COrderNo { get; set; }
        public DateTime? DShipmentDate { get; set; }
        public string CDeliveryStatus { get; set; }
        public DateTime? DActualDeliveryDate { get; set; }

        public virtual Order COrderNoNavigation { get; set; }
    }
}
