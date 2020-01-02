using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.Rest.Verify.V2.Service;
using CoreShop_V2.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using CoreShop_V2.Service;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TwilioController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public TwilioController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Account/CheckSms")]
        public async Task<IActionResult> SendSms(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            //var message = MessageResource.Create(
            //    body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
            //    from: new PhoneNumber("+16193784698"),
            //    to: new PhoneNumber("+84395558787")
            //);
            string number = user.PhoneNumber;
            number = "+84" + number.Substring(1);
            string serid = TwilioService.PathServiceSid;
            var verification = VerificationResource.Create(
                to: number,
                channel: "sms",
                pathServiceSid: serid
            );
            ViewData["verSid"] = verification.Sid;
            return View();
        }

        [Route("CheckSms")]
        [HttpPost]
        public async Task<IActionResult> CheckSms(string sid,string code,string userId,string isPersistent)
        {            
            var verificationCheck = VerificationCheckResource.Create(
                verificationSid: sid,
                code: code,
                pathServiceSid: TwilioService.PathServiceSid
            );           

            if (verificationCheck.Valid == true)
            {
                var user = await _userManager.FindByIdAsync(userId);
                bool isPer = false;
                if (isPersistent == "True") isPer = true;
                await _signInManager.SignInAsync(user, isPer);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}