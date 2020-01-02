using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreShop_V2.Areas.Client.Controllers
{
    [Produces("application/xml")]
    public class RssController : Controller
    {
        private readonly MyDbContext _context;
        public RssController(MyDbContext context)
        {
            _context = context;
        }        
        public IActionResult Index()
        {
            XNamespace ns = "http://www.w3.org/2005/Atom";
            var rss = new XElement("rss", new XAttribute("version", "2.0"), new XAttribute(XNamespace.Xmlns + "atom", ns));
            var channel = new XElement("channel",
               new XElement("title", "XanaduShop"),
               new XElement("description", "Xanadu RSS"),
               new XElement("language", "en-us"),
               //todo: add blogChannel tags
               new XElement("copyright", $"Copyright 2019-{DateTime.UtcNow.Year} Xanadu"),
               new XElement("category", "Ecommerce Website"),
               new XElement(ns + "link", new XAttribute("href", "http://localhost:44379/rss"), new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml"))
            );
            foreach (var item in _context.Product.Include(p => p.category))
            {
                var postInRss = new XElement("item");
                postInRss.Add(new XElement("title", item.ProductName));
                postInRss.Add(new XElement("description", item.Describe));
                postInRss.Add(new XElement("price", item.Price));
                postInRss.Add(new XElement("category", item.category.CategoryName));
                postInRss.Add(new XElement("link", string.Format("http://localhost:44379/product/{0}/{1}", item.CategoryNameSeo, item.ProductNameSeo)));
                channel.Add(postInRss);
            }

            rss.Add(channel);

            return Ok(rss);

        }
    }



}