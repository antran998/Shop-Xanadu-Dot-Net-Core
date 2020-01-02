using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Service
{
    public class TwilioService
    {
        public static string AccountSID { get; set; }
        public static string AuthToken { get; set; }
        public static string PathServiceSid { get; set; }
        static TwilioService()
        {            
            AccountSID = BuilderService.config["Twilio:AccountSID"];
            AuthToken = BuilderService.config["Twilio:AuthToken"];
            PathServiceSid = BuilderService.config["Twilio:PathServiceSid"];
        }
    }
}
