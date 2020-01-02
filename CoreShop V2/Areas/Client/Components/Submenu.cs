using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Client.Components
{
    public class Submenu : ViewComponent
    {
        private readonly MyDbContext _context;

        public Submenu(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var catagory = await _context.Category.Include(x => x.product).ToListAsync();
            return View(catagory);
        }
    }
}
