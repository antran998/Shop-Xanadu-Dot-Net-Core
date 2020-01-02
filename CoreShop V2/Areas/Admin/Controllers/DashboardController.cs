using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CoreShop_V2.Areas.Admin.ViewModel;
using CoreShop_V2.Areas.Admin.ViewModel.CategorySaleViewModel;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly MyDbContext _dbContext;

        public DashboardController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("Totalsale")]
        [HttpPost]
        public async Task<IActionResult> Totalsale()
        {
            var statistic = new SaleStatisticViewModel();
            
            for (double i = 0; i < 7; i++)
            {
                DateTime dateTime = DateTime.Now; 
                var date = dateTime.AddDays(-i);                
                statistic.time.Add(date.ToString("d"));
            }

            var listTotalSale = await _dbContext.BillDetails.Include(x => x.Bill).GroupBy(x => x.Bill.CreateDate.Date, x => x.TotalPrice,
                (key, g) => new { Date = key, TotalSale = g.Sum().ToString() }).ToListAsync();

            foreach (var date in statistic.time)
            {
                var saleOfdate = listTotalSale.Where(x=>x.Date.ToString("d")==date).Select(x=>x.TotalSale).FirstOrDefault();
                if (String.IsNullOrEmpty(saleOfdate)) saleOfdate = "0";
                statistic.totalsale.Add(saleOfdate);
            }

            var listActualSale = await _dbContext.BillDetails.Include(x => x.Bill).Where(x=>x.Bill.Status==true).GroupBy(x => x.Bill.CreateDate.Date, x => x.TotalPrice,
                (key, g) => new { Date = key, TotalSale = g.Sum().ToString() }).ToListAsync();

            foreach (var date in statistic.time)
            {
                var saleOfdate = listActualSale.Where(x => x.Date.ToString("d") == date).Select(x => x.TotalSale).FirstOrDefault();
                if (String.IsNullOrEmpty(saleOfdate)) saleOfdate = "0";
                statistic.actualsale.Add(saleOfdate);
            }

            for(int i = 0; i < statistic.time.Count; i++)
            {
                statistic.time[i] = statistic.time[i].Replace("/2019", "");
            }

            return Json(statistic);
        }

        [Route("Catagorysale")]
        //[HttpPost]
        public async Task<IActionResult> Catagorysale()
        {
            var catagorySale = new CatagorySaleViewModel();            
            
            var sale = await _dbContext.BillDetails.Include(x => x.Bill).Where(x => x.Bill.Status == true).GroupBy(x => x.ProductId, x => x.TotalPrice,
                (key, g) => new Sale {Catagory="", ProductId = key, TotalSale = g.Sum() }).ToListAsync();

            foreach (var item in sale)
            {
                var type = await _dbContext.Product.Include(x => x.category)
                    .FirstOrDefaultAsync(x => x.ProductId == item.ProductId);
                item.Catagory = type.category.CategoryName;
            }

            var saleresult = sale.GroupBy(x => x.Catagory, x => x.TotalSale,
                (key, g) => new { Catagory = key, Totalsale = g.Sum().ToString() }).ToList();

            foreach (var item in saleresult)
            {
                Random random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                catagorySale.legend.Add(item.Catagory);
                catagorySale.sale.Add(item.Totalsale);
                catagorySale.color.Add(color);
            }
            return Json(catagorySale);
        }
    }
}