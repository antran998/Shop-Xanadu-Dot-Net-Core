using FinalProjectASPDotnet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectASPDotnet.Areas.Admin.Models
{
    [JsonObject(IsReference = true)]
    public class TopSelling
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int? SellingQuantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
