using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel
{
    public class SignupViewModel
    {
        
        [Required]
        [RegularExpression(@"^.[^\d]{5,}$", ErrorMessage = "5 characters or more")]
        public string CustomerName { get; set; }
        
        [Required]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "5 characters or more")]
        public string CustomerAddress { get; set; }
        
        [Required]
        [RegularExpression(@"^[0][0-9]{9}$", ErrorMessage = "Incorrect Format")]
        public string CustomerPhone { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-z][^0][a-z0-9_\.\-]{3,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "Incorrect Format")]
        [Remote(action: "IsEmailInUse", controller: "Identity",areaName:"admin")]
        public string CustomerEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,})", ErrorMessage = "Sai định dạng")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Không khớp mật khẩu")]
        public string ConfirmPassword { get; set; }             
    }
}
