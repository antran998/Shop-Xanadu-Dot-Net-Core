using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel
{
    public class CatagorySaleViewModel
    {
        public List<string> color { get; set; }
        public List<string> legend { get; set; }
        public List<string> sale { get; set; }
        public CatagorySaleViewModel()
        {
            color = new List<string>();
            legend = new List<string>();
            sale = new List<string>();
        }
    }
}
