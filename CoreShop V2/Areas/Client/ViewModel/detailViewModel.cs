using FinalProjectASPDotnet.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Client.ViewModel
{
    public class DetailViewModel
    {
        public Product HangHoa { get; set; }
        public IEnumerable<Rating> DanhGia { get; set; }
        public IEnumerable<Product> RelateProduct { get; set; }

    }
}
