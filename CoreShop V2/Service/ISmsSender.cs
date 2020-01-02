using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Service
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
