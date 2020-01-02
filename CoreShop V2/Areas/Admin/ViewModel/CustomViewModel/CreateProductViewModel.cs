using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel
{
    public class CreateProductViewModel
    {        
        [Required]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "5 characters or more")]
        [Remote(action:"IsProductExist",controller:"MgnProduct")]
        public string ProductName { get; set; }
        public string CateName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Number only")]
        public double Price { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Number only")]
        public double DiscountPrice { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public string Describe { get; set; }
    }
}
