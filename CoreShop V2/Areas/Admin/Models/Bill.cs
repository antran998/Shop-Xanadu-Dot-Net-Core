using CoreShop_V2.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectASPDotnet.Areas.Admin.Models
{    
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetails>();
        }
        public string BillId { get; set; }        
        public DateTime CreateDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public bool Status { get; set; }
        public string AccountId { get; set; }        
        public virtual ApplicationUser Account { get; set; }
        public virtual ICollection<BillDetails> BillDetails { get; set; }
    }
}
