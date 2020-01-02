using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Image { get; set; }
    }
}
