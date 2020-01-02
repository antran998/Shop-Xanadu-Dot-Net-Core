using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel
{
    public class UpdateProductViewModel
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "5 charaters or more")]        
        public string ProductName { get; set; }
        public string CateName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Number only")]
        public double Price { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Number only")]
        public double DiscountPrice { get; set; }
        public IFormFile Image { get; set; }
        public string Describe { get; set; }
    }
}
