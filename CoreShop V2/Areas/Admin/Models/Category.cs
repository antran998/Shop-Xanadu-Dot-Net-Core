using FinalProjectASPDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectASPDotnet.Areas.Admin.Models
{
    [JsonObject(IsReference =true)]
    public partial class Category
    {
        public Category()
        {
            product = new HashSet<Product>();
        }
        [Key]
        public string CateID { get; set; }
        public string CategoryName { get; set; }
        
        public virtual ICollection<Product> product { get; set; }
        //public virtual List<Product> Items { get; set; }
    }
}
