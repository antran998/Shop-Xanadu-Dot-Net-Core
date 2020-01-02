
using CoreShop_V2.Areas.Admin.Models;
using CoreShop_V2.Areas.Admin.ViewModel.MemberViewModel;
using CoreShop_V2.Areas.Client.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel
{
    public class UserManagementViewModel
    {
        public List<UserRoleViewModel> UserWithRole { get; set; }
        public CreateUserViewModel CreateUser { get; set; }
        public UpdateUserViewModel UpdateUser { get; set; }
        public UserManagementViewModel()
        {
            UserWithRole = new List<UserRoleViewModel>();
        }
    }
}
