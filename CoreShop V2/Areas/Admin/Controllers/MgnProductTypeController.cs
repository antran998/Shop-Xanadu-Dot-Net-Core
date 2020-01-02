using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreShop_V2.Areas.Admin.ViewModel;
using CoreShop_V2.Areas.Admin.ViewModel.CustomClass;
using CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MgnProductTypeController : Controller
    {
        private readonly MyDbContext _dbContext;        
        private readonly IMapper _mapper;

        public MgnProductTypeController(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Route("ProductTypeMgn")]
        public async Task<IActionResult> ProductTypeMgn(string newItem)
        {
            ProductManagementViewModel productMgnVM = new ProductManagementViewModel();
            var productTypes = await _dbContext.Category.ToListAsync();
            var products = await _dbContext.Product.ToListAsync();
            productMgnVM.Types = _mapper.Map<List<ProductTypeViewModel>>(productTypes);
            if (newItem != null)
            {
                productMgnVM.CreateSuccess = newItem;
            }

            return View(productMgnVM);
        }

        [HttpPost]
        [Route("AddType")]
        public async Task<IActionResult> AddType(CreateTypeViewModel CreateType)
        {
            if (ModelState.IsValid)
            {
                Category newType = new Category
                {
                    CategoryName = CreateType.CategoryName
                };

                await _dbContext.Category.AddAsync(newType);
                var created = await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ProductTypeMgn", new { newItem = CreateType.CategoryName });
        }

        [HttpGet]
        public async Task<IActionResult> IsTypeExist(CreateTypeViewModel CreateType)
        {
            var isExist = await _dbContext.Category.FirstOrDefaultAsync(x =>
                x.CategoryName == CreateType.CategoryName);
            if (isExist == null)
            {
                return Json(true);
            }
            return Json($"Type is already existed");
        }

        [HttpPost]
        [Route("DeleteType")]
        public async Task<IActionResult> DeleteType(string Name)
        {
            var type = await _dbContext.Category.FirstOrDefaultAsync(x => x.CategoryName == Name);
            var product = await _dbContext.Product.FirstOrDefaultAsync(x => x.CateId == type.CateID);

            if (product == null)
            {
                _dbContext.Category.Remove(type);
                var deleted = await _dbContext.SaveChangesAsync();

                return Json("success");
            }
            else
            {
                return Json("This type has products !");
            }
        }
    }
}