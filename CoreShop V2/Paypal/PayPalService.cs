using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreShop_V2.Service;

namespace CoreShop_V2.Paypal
{
    public class PayPalService
    {
        public static PayPalConfig GetPayPalConfig()
        {            
            return new PayPalConfig()
            {
                AuthToken = BuilderService.config["PayPal:AuthToken"],
                Business = BuilderService.config["PayPal:Business"],
                PostUrl = BuilderService.config["PayPal:PostUrl"],
                ReturnUrl = Hosting.Name + BuilderService.config["PayPal:ReturnUrl"]
            };
        }
    }
}
