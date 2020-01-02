using FinalProjectASPDotnet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectASPDotnet.Areas.Admin.Models
{
    [JsonObject(IsReference = true)]
    public partial class Product  {
        
        public Product()
        {
            TopSelling = new HashSet<TopSelling>();
        }
        public string  ProductId { get; set; }
        public string ProductName { get; set; }
        public string CateId  { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string Image { get; set; }        
        public string Describe { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Category category { get; set; }
        public virtual ICollection<TopSelling> TopSelling { get; set; }
        public string ProductNameSeo => ProductName.ToUrlFriendly();
        public string CategoryNameSeo => category.CategoryName.ToUrlFriendly();
    }
}
