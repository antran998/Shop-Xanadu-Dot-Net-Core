using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Service
{
    public class Gmail
    {
        public static string MyGmail { get; set; }
        public static string Password { get; set; }
        static Gmail()
        {
            MyGmail = BuilderService.config["MyMail:MyGmail"];
            Password = BuilderService.config["MyMail:Password"];
        }
    }
}
