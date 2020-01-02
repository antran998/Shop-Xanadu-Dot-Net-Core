using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel
{
    public class ProductViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CateId { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string Image { get; set; }
        public string Describe { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
