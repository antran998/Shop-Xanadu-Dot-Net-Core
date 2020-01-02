using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Service
{
    public class BuilderService
    {
        public static IConfigurationRoot config { get; set; }
        static BuilderService()
        {
            var directory = "C:/Users/Admin/AppData/Roaming/Microsoft/UserSecrets/db9ab7de-df52-4874-8770-82761f58dc17";
            var builder = new ConfigurationBuilder().SetBasePath(directory).AddJsonFile("secrets.json");
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            config = builder.Build();
        }
    }
}
