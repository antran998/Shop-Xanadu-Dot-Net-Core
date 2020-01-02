using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.Areas.Admin.ViewModel
{
    public class IdentityViewModel
    {
        public LoginViewModel login { get; set; }
        public SignupViewModel signup { get; set; }
        public string invalid { get; set; }
        public string confirmed { get; set; }
        public IdentityViewModel()
        {
            login = new LoginViewModel();
        }
    }
}
