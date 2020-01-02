using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoreShop_V2.Service
{
    public class Hosting
    {
        public static string Name { get; set; }
        static Hosting()
        {
            Name = "https://localhost:44379";
        }
    }
}
