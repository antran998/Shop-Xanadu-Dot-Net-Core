using CoreShop_V2.Areas.Client.ViewModel;
using CoreShop_V2.Service;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }
        [Route("")]
        [Route("Home")]
        public async Task<IActionResult> Index(int? category)
        {
            var name = Hosting.Name;
            HomeViewModel ViewModel = new HomeViewModel();

            ViewModel.HangHoa = await _context.Product.ToListAsync();

            var Context = _context.Product.Include(p => p.category).OrderBy(p => p.ProductId);
            var data = await _context.Product.ToListAsync();
            ViewModel.NewArrivalHangHoa = Context;
            //ViewModel.NewArrivalHangHoa = (from t in data
            //                               select t).Take(10);
                       
            var aaa = _context.BillDetails.GroupBy(x => x.ProductId,x=>x.Quantity,(key,g)=> new { ProductId = key, Quanity = g.Sum() })
                .OrderByDescending(x=>x.Quanity);
            ViewModel.TopSellHangHoa = (from t in aaa
                                       from p in data
                                       where p.ProductId == t.ProductId
                                       select p).Take(10);
            return View(ViewModel);
        }        
    }

}
