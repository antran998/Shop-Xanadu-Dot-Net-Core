using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreShop_V2.Areas.Client.Controllers
{
    [Area("Client")]
    public class FaqController : Controller
    {
        [Route("FAQ")]
        public IActionResult Faq()
        {
            return View();
        }
    }
}