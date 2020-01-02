using CoreShop_V2.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel.MemberViewModel
{
    public class UserRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Image { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
