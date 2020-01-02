using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShop_V2.Areas.Admin.Models;
using CoreShop_V2.Areas.Admin.ViewModel;
using CoreShop_V2.Areas.Admin.ViewModel.MemberViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MgnRoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public MgnRoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("UserRoleMgn")]
        public async Task<IActionResult> UserRoleMgn()
        {
            UserManagementViewModel userMgnViewModel = new UserManagementViewModel();
            IEnumerable<ApplicationRole> Roles = _roleManager.Roles;
            //IEnumerable<ApplicationUser> Users = _userManager.Users;
            
            foreach (var role in Roles)
            {
                userMgnViewModel.UserWithRole.Add(new UserRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Image = role.Image,
                    Users = await _userManager.GetUsersInRoleAsync(role.Name)
                });
            }
            
            return View(userMgnViewModel);
        }
    }
}