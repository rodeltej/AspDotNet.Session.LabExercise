using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyUniverseData.Models
{
    public partial class Wrapper
    {
        public Wrapper()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string CWrapperId { get; set; }
        public string VDescription { get; set; }
        public decimal MWrapperRate { get; set; }
        public byte[] ImPhoto { get; set; }
        public string VWrapperImgPath { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
