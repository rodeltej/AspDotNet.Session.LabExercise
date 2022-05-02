using System.Collections.Generic;
using ToyData.Models;

namespace ToyWeb.Models
{
    public class ToyPage
    {
        public List<Toy> ToyList { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
