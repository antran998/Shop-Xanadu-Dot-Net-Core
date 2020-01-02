using FinalProjectASPDotnet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectASPDotnet.Areas.Admin.Models
{    
    public partial class BillDetails
    {        
        public string BillDetailsId { get; set; }
        public string BillId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        [JsonIgnore]
        public virtual Bill Bill { get; set; }
    }
}
