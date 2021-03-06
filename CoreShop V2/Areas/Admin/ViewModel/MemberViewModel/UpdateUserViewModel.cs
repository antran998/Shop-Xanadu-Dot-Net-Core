﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.MemberViewModel
{
    public class UpdateUserViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [RegularExpression(@"^.[^\d]{5,}$", ErrorMessage = "5 characters or more")]
        public string CustomerName { get; set; }

        [Required]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "5 characters or more")]
        public string CustomerAddress { get; set; }

        [Required]
        [RegularExpression(@"^[0][1-9]{9}$", ErrorMessage = "Incorrect Format")]
        public string CustomerPhone { get; set; }

        [Required]
        [RegularExpression(@"^[a-z][^0][a-z0-9_\.\-]{3,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "Incorrect Format")]        
        public string CustomerEmail { get; set; }
                
        [DataType(DataType.Password)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,})", ErrorMessage = "Incorrect Format")]
        public string Password { get; set; }
                
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
