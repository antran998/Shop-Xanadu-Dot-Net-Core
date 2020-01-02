using FinalProjectASPDotnet.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel
{
    public class BillMgnViewModel
    {
        public string BillId { get; set; }
        public string CreateDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string Status { get; set; }
        public string AccountId { get; set; }
        public IEnumerable<BillDetails> BillDetails { get; set; }
    }
}
