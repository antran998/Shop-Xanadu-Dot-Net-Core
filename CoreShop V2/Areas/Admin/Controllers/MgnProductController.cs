using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreShop_V2.Areas.Admin.ViewModel;
using CoreShop_V2.Areas.Admin.ViewModel.CustomClass;
using CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MgnProductController : Controller
    {
        private readonly MyDbContext _dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public MgnProductController(MyDbContext dbContext, IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        [Route("ProductMgn/{typeId}")]
        public async Task<IActionResult> ProductMgn(string typeId)
        {
            ProductManagementViewModel productMgnVM = new ProductManagementViewModel();
            var productTypes = await _dbContext.Category.Where(x=>x.CateID==typeId).ToListAsync();
            productMgnVM.Types = _mapper.Map<List<ProductTypeViewModel>>(productTypes);

            return View(productMgnVM);
        }

        [HttpPost]
        [Route("LoadData")]
        public async Task<IActionResult> LoadData(string CateId)
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
                // Getting all data
                var productTemp = await _dbContext.Product.Where(x => x.CateId == CateId).ToListAsync();
                var products = _mapper.Map<List<ProductViewModel>>(productTemp);
                
                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    products = products.OrderBy(x => x.ProductId).ToList();
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    var itemSearch = products.Where(m => m.ProductName.ToString().Contains(searchValue)).ToList();
                    var leftOver = products.Except(itemSearch).ToList();

                    itemSearch.AddRange(leftOver.Where(m => m.Price.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(itemSearch).ToList();

                    itemSearch.AddRange(leftOver.Where(m => m.DiscountPrice.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(itemSearch).ToList();
                    
                    products = itemSearch;
                }

                //total number of rows count   
                recordsTotal = products.Count();
                //Paging   
                var data = products.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }   

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel CreateProduct)
        {
            var type = await _dbContext.Category.FirstOrDefaultAsync(x =>
                x.CategoryName == CreateProduct.CateName);
            if (ModelState.IsValid)
            {
                Product newProduct = new Product
                {
                    CateId = type.CateID,
                    ProductName = CreateProduct.ProductName,
                    Describe = CreateProduct.Describe,
                    Price = CreateProduct.Price,
                    DiscountPrice = CreateProduct.DiscountPrice,
                    Image = SetPhotoPath(CreateProduct.Image),
                    CreatedDate = DateTime.Now
                };

                await _dbContext.Product.AddAsync(newProduct);
                var created = await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ProductMgn", new { typeId = type.CateID , created = "success"});
        }

        string SetPhotoPath(IFormFile Image)
        {
            string uniqueFileName = null;

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "assets/images/items");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            Image.CopyTo(new FileStream(filePath, FileMode.Create));

            return uniqueFileName;
        }

        [HttpGet]
        public async Task<IActionResult> IsProductExist(CreateProductViewModel CreateProduct)
        {
            var isExist = await _dbContext.Product.FirstOrDefaultAsync(x =>
                x.ProductName == CreateProduct.ProductName);
            if (isExist == null)
            {
                return Json(true);
            }
            return Json("Product is already existed");
        }
                
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel UpdateProduct)
        {
            var type = await _dbContext.Category.FirstOrDefaultAsync(x =>
                x.CategoryName == UpdateProduct.CateName);
            var currProduct = await _dbContext.Product.FirstOrDefaultAsync(x =>
                x.ProductId == UpdateProduct.ProductId);
            if (ModelState.IsValid)
            {                
                currProduct.CateId = type.CateID;
                currProduct.ProductName = UpdateProduct.ProductName;
                currProduct.Describe = UpdateProduct.Describe;
                currProduct.Price = UpdateProduct.Price;
                currProduct.DiscountPrice = UpdateProduct.DiscountPrice;
                
                if (UpdateProduct.Image != null)
                {
                    DeleteImage(currProduct.Image);
                    currProduct.Image = SetPhotoPath(UpdateProduct.Image);
                }

                _dbContext.Product.Update(currProduct);
                var updated = await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ProductMgn", new { typeId = type.CateID, updated =  currProduct.ProductId});
        }

        void DeleteImage(string imageName)
        {
            var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "assets/images/items");
            var imagePath = Path.Combine(folderPath, imageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(string ProductId)
        {            
            var currProduct = await _dbContext.Product.FirstOrDefaultAsync(x =>
                x.ProductId == ProductId);

            DeleteImage(currProduct.Image);
            _dbContext.Product.Remove(currProduct);
            var updated = await _dbContext.SaveChangesAsync();
        
            return Json("success");
        }
    }
}