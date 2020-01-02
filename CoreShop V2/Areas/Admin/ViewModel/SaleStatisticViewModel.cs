using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel
{
    public class SaleStatisticViewModel
    {
        public List<string> time { get; set; }
        public List<string> totalsale { get; set; }
        public List<string> actualsale { get; set; }
        public SaleStatisticViewModel()
        {
            time = new List<string>();
            totalsale = new List<string>();
            actualsale = new List<string>();
        }
    }
}
