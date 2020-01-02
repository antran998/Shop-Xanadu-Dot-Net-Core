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
    [Authorize(Roles ="Admin")]
    public class MgnUserController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public MgnUserController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("UserMgn/{roleId}")]
        public async Task<IActionResult> UserMgn(string roleId)
        {
            UserManagementViewModel userMgnViewModel = new UserManagementViewModel();            
            ApplicationRole role = await _roleManager.FindByIdAsync(roleId);            

            userMgnViewModel.UserWithRole.Add(new UserRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Image = role.Image,
                Users = await _userManager.GetUsersInRoleAsync(role.Name)
            });

            return View(userMgnViewModel);
        }

        [HttpPost]
        [Route("LoadUserData")]
        public async Task<IActionResult> LoadData(string roleId)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var role = await _roleManager.FindByIdAsync(roleId);

                // Getting all data  
                var users = await _userManager.GetUsersInRoleAsync(role.Name);               

                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    users = users.OrderBy(x => x.Id).ToList();
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    var userSearch = users.Where(m => m.Fullname.Contains(searchValue)).ToList();
                    var leftOver = users.Except(userSearch).ToList();

                    userSearch.AddRange(leftOver.Where(m => m.Email.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(userSearch).ToList();

                    userSearch.AddRange(leftOver.Where(m => m.PhoneNumber.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(userSearch).ToList();

                    userSearch.AddRange(leftOver.Where(m => m.Address.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(userSearch).ToList();

                    userSearch.AddRange(leftOver.Where(m => m.MoneySpended.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(userSearch).ToList();

                    users = userSearch;
                }

                //total number of rows count   
                recordsTotal = users.Count();
                //Paging   
                var data = users.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Route("CreateRole")]
        //[HttpPost]
        //public async Task<IActionResult> CreateRole(UserManagementViewModel userManagementViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityRole identityRole = new IdentityRole
        //        {
        //            Name = userManagementViewModel.createRoleViewModel.RoleName
        //        };

        //        IdentityResult result = await _roleManager.CreateAsync(identityRole);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("UserManagement");
        //        }

        //        foreach (IdentityError error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }

        //    return View("UserManagement", userManagementViewModel);
        //}

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel CreateUser)
        {
            var currRoleId = await _roleManager.FindByNameAsync(CreateUser.UserRole);
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = CreateUser.CustomerEmail, Email = CreateUser.CustomerEmail, PhoneNumber = CreateUser.CustomerPhone, Address = CreateUser.CustomerAddress, Fullname = CreateUser.CustomerName };
                var result = await _userManager.CreateAsync(user, CreateUser.Password);

                if (result.Succeeded)
                {
                    var newUser = await _userManager.FindByEmailAsync(user.Email);
                    var addToRole = await _userManager.AddToRoleAsync(newUser, CreateUser.UserRole);                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("UserMgn", new { roleId = currRoleId.Id, created = "success" });
        }
                
        [HttpGet]
        public async Task<IActionResult> IsEmailInUse(CreateUserViewModel CreateUser)
        {
            var user = await _userManager.FindByEmailAsync(CreateUser.CustomerEmail);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json("Email is already in use");
            }
        }

        [Route("UpdateUser")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel UpdateUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(UpdateUser.UserId);
                
                if (UpdateUser.Password != null)
                {
                    var removePassword = await _userManager.RemovePasswordAsync(user);
                    var addPassword = await _userManager.AddPasswordAsync(user, UpdateUser.Password);
                    foreach (var error in addPassword.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                user.Fullname = UpdateUser.CustomerName;
                user.Email = UpdateUser.CustomerEmail;
                user.Address = UpdateUser.CustomerAddress;
                user.PhoneNumber = UpdateUser.CustomerPhone;
                user.UserName = UpdateUser.CustomerEmail;

                var result = await _userManager.UpdateAsync(user);
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }                
            }

            return RedirectToAction("UserMgn", new { roleId = UpdateUser.RoleId, updated = UpdateUser.UserId });            
        }

        [Route("DeleteUser")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var delete = await _userManager.DeleteAsync(user);
            if (delete.Succeeded)
            {
                return Json("success");
            }
            return RedirectToAction("UserMgn");
        }
    }
}