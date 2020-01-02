using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel
{
    public class CreateTypeViewModel
    {   
        [Required]
        [MinLength(2,ErrorMessage ="Two characters or more")]
        [Remote(action: "IsTypeExist",controller:"MgnProductType")]
        public string CategoryName { get; set; }
    }
}
