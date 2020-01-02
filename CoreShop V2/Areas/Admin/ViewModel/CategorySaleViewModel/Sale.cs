using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.CategorySaleViewModel
{
    public class Sale
    {
        public string Catagory { get; set; }
        public string ProductId { get; set; }
        public double TotalSale { get; set; }
    }
}
