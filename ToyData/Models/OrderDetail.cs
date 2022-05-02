using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyData.Models;

namespace ToyUniverseData.Models
{
    public partial class OrderDetail
    {
        public string COrderNo { get; set; }
        public string CToyId { get; set; }
        public short SiQty { get; set; }
        public string CGiftWrap { get; set; }
        public string CWrapperId { get; set; }
        public string VMessage { get; set; }
        public decimal? MToyCost { get; set; }

        public virtual Order COrderNoNavigation { get; set; }
        public virtual Toy CToy { get; set; }
        public virtual Wrapper CWrapper { get; set; }
    }
}
