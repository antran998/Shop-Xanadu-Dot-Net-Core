using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShop.ViewModels;
using CoreShop_V2.Areas.Admin.Models;
using CoreShop_V2.Areas.Client.ViewModel;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreShop.Controllers
{
    [Area("client")]
    public class ProductsController : Controller
    {
        private MyDbContext _context;
        private IQueryable<Product> products;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProductsController(MyDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
               
        [Route("products")]
        public async Task<IActionResult> Products(string sortOrder, int? pageNumber,string searchString)
        {
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "0";
            }

            products = _context.Product.Include(x=>x.category);
            ProductsViewModel productsViewModel = new ProductsViewModel();
            List<SelectListItem> options = new List<SelectListItem>
            {
                new SelectListItem { Text="All",Value ="0"},
                new SelectListItem { Text="Price: Low to high",Value ="price_asc"},
                new SelectListItem { Text="Price: High to low",Value ="price_desc"},                
            };

            var type = await _context.Category.ToListAsync();
            foreach (var item in type)
            {                
                var listItem = new SelectListItem
                {
                    Text = "Type: " + item.CategoryName,
                    Value = item.CategoryName
                };
                options.Add(listItem);
            }
                        
            switch (sortOrder)
            {
                case "price_desc":
                    products = products.OrderByDescending(i => i.Price);
                    options[2].Selected = true;
                    break;
                case "price_asc":
                    products = products.OrderBy(i => i.Price);
                    options[1].Selected = true;
                    break;
                case "0":
                    products = products.OrderByDescending(i => i.ProductId);
                    options[0].Selected = true;
                    break;
                default:
                    products = products.Where(i=>i.category.CategoryName==sortOrder);
                    options[0].Selected = true;
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                productsViewModel.searchString = searchString;
                products = products.Where(p => p.ProductName.Contains(searchString));
            }

            int pageSize = 10;

            productsViewModel.items = await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize);
            productsViewModel.TotalItem = products;
            productsViewModel.Options = options;
            
            return View(productsViewModel);
        }        

        [Route("products/SearchAndSort")]
        [HttpPost]
        public IActionResult SearchSort()
        {            
            return RedirectToActionPreserveMethod("products");
        }

        [Route("product")]
        [Route("product/{category}/{ProductName}")]
        public async Task<IActionResult> ProductDetail(string id, string ProductName, string category)
        {
            DetailViewModel model = new DetailViewModel();
            if (ProductName == null && category == null)
            {
                model.HangHoa = await _context.Product.Include(p => p.category).FirstOrDefaultAsync();
                var data = _context.Product.Include(p => p.category);
                model.RelateProduct = (from t in data
                                       where t.category.CategoryName == model.HangHoa.CategoryNameSeo
                                       select t).Take(5);
            }
            else
            {
                model.HangHoa = await _context.Product
                .Include(h => h.category)
                .FirstOrDefaultAsync(m => m.ProductNameSeo.Equals(ProductName));
                var data = _context.Product.Include(p => p.category);
                model.RelateProduct = (from t in data
                                       where t.category.CategoryName == category
                                       select t).Take(5);
            }

            model.DanhGia = await _context.Rating.Include(p => p.Account).Where(x=>x.ProductId == model.HangHoa.ProductId).ToListAsync();

            var tmp = _context.Rating.Where(p => p.ProductId == model.HangHoa.ProductId).Sum(p => p.Ratings);
            var quantity = _context.Rating.Where(p => p.ProductId == model.HangHoa.ProductId).Count();
            if (quantity == 0)
            {
                ViewBag.RatingAve = 0;
            }
            else
            {
                ViewBag.RatingAve = tmp / quantity;
            }

            if (model.HangHoa == null)
            {
                return NotFound();
            }

            return View(model);

        }

        [HttpPost]
        [Route("products/AddComment")]
        public async Task<IActionResult> AddComment(string inputReview, string Ratings, string ProductId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Rating rt = new Rating();
            if (ProductId == null)
            {
                ProductId = "1";
            }
            rt.ProductId = ProductId;
            rt.Comment = inputReview;
            rt.Ratings = Convert.ToInt32(Ratings);
            rt.Account = user;
            if (ModelState.IsValid)
            {
                await _context.Rating.AddAsync(rt);
                await _context.SaveChangesAsync();
                return Json("Added");
            }
            return Json("Success");
        }


    }
}