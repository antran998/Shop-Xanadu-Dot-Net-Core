using CoreShop_V2.Areas.Admin.ViewModel.CustomClass;
using CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel
{
    public class ProductManagementViewModel
    {
        // Type
        public List<ProductTypeViewModel> Types { get; set; }
        public CreateTypeViewModel CreateType { get; set; }
        // Type

        // Product
        public CreateProductViewModel CreateProduct { get; set; }
        public UpdateProductViewModel UpdateProduct { get; set; }
        // Product

        public string CreateSuccess { get; set; } // contain type name
        public ProductManagementViewModel()
        {
            CreateType = new CreateTypeViewModel();
            CreateProduct = new CreateProductViewModel();
        }


    }
}
