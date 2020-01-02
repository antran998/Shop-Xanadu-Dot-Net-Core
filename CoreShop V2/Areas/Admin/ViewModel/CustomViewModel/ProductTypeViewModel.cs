using FinalProjectASPDotnet.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.CustomClass
{
    public class ProductTypeViewModel
    {
        public string CateID { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
        public ProductTypeViewModel()
        {
            CategoryName = "";
        }
    }
}
