using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyData.Models;

namespace ToyUniverseData.Models
{
    public partial class ToyBrand
    {
        public ToyBrand()
        {
            Toys = new HashSet<Toy>();
        }

        public string CBrandId { get; set; }
        public string CBrandName { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
