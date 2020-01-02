using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Service
{
    public class MailChimpService
    {        
        public static string MailSid { get; set; }
        public static string MailListId { get; set; }
        static MailChimpService()
        {
            MailSid = BuilderService.config["MailChimp:MailSid"];
            MailListId = BuilderService.config["MailChimp:MailListId"];
        }
    }
}
