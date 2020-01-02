using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Castle.Core.Logging;
using CoreShop_V2.Areas.Admin.Models;
using CoreShop_V2.Areas.Admin.ViewModel;
using CoreShop_V2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MimeKit;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IdentityController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IHostingEnvironment _env;
        private readonly IEmailSender _emailSender;        

        public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IHostingEnvironment env, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _env = env;
            _emailSender = emailSender;            
        }

        [Route("Account/Login")]
        [Route("Account/Signup")]
        public async Task<IActionResult> Login(string returnUrl,string confirmed, string invalid)
        {
            IdentityViewModel identityViewModel = new IdentityViewModel();
            //identityViewModel.invalid = false;
            if (!string.IsNullOrEmpty(confirmed)) identityViewModel.confirmed = confirmed;
            if (!string.IsNullOrEmpty(invalid)) 
            {
                if(invalid == "upw") identityViewModel.invalid = "Username and password combination wrong";
                else identityViewModel.invalid = "Email not confirmed yet";
            }
            
            identityViewModel.login.ReturnUrl = returnUrl;
            identityViewModel.login.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            
            return View(identityViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> IsEmailInUse(IdentityViewModel identityViewModel)
        {
            var user = await _userManager.FindByEmailAsync(identityViewModel.signup.CustomerEmail);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json("Email is already in use");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel signup, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = signup.CustomerEmail, Email = signup.CustomerEmail, PhoneNumber = signup.CustomerPhone, Address = signup.CustomerAddress, Fullname = signup.CustomerName };
                var result = await _userManager.CreateAsync(user, signup.Password);

                if (result.Succeeded)
                {
                    var newUser = await _userManager.FindByEmailAsync(user.Email);
                    var addToRole = await _userManager.AddToRoleAsync(newUser, "User");

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    //var confirmationLink = Url.Action("ConfirmEmail", "Identity",
                    //                       new { userId = user.Id, token = token }, Request.Scheme);

                    return RedirectToAction("SendEmailConfirm", new { userId = user.Id,token = token});
                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    //if (!string.IsNullOrEmpty(ReturnUrl))
                    //{
                    //    return Redirect(ReturnUrl);
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "Home", new { Area = "Client" });
                    //}
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("login", signup);
        }

        [Route("SendEmailConfirm")]        
        public async Task<IActionResult> SendEmailConfirm(string token,string userId)
        {
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(token)) return NotFound();
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {   
                ProcessEmail(user.Email, "2", token, userId);
            
                return RedirectToAction("login", new { confirmed = "Please check your email to confirm !" });
            }

            return NotFound();
        }
                
        [Route("Account/Confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return NotFound();
            }
            token = token.Replace(" ", "+");
            var result = await _userManager.ConfirmEmailAsync(user, token);
            
            if (result.Succeeded)
            {
                return RedirectToAction("login", new { confirmed = "Email is confirmed !" });
            }
            return NotFound();
        }

        [HttpPost]        
        public async Task<IActionResult> LoginIn(IdentityViewModel identityViewModel, string ReturnUrl)
        {            
            identityViewModel.login.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(identityViewModel.login.LoginEmail);

                if(user != null && !user.EmailConfirmed && 
                    (await _userManager.CheckPasswordAsync(user,identityViewModel.login.LoginPassword)))
                {
                    return RedirectToAction("login",new { invalid = "enc"});                    
                }

                return RedirectToAction("SendSms","Twilio",new { userId = user.Id, isPersistent = identityViewModel.login.RememberMe });
                //var result = await _signInManager.PasswordSignInAsync(identityViewModel.login.LoginEmail, identityViewModel.login.LoginPassword, identityViewModel.login.RememberMe, false);
                
                //if (result.Succeeded)
                //{
                //    if (!string.IsNullOrEmpty(ReturnUrl))
                //    {
                //        return Redirect(ReturnUrl);
                //    }
                //    else
                //    {
                //        return RedirectToAction("Index", "Home", new { Area = "Client" });
                //    }
                //}

            }
            return RedirectToAction("login", new { invalid = "upw" });            
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {             
            var redirectUrl = Url.Action("ExternalLoginCallback", "Identity", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            IdentityViewModel identityViewModel = new IdentityViewModel();
            //identityViewModel.invalid = false;
            identityViewModel.login.ReturnUrl = returnUrl;
            identityViewModel.login.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            
            if(remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", identityViewModel);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return View("Login", identityViewModel);
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            ApplicationUser user = null;

            if (email != null)
            {
                user = await _userManager.FindByEmailAsync(email);

                if (user != null && !user.EmailConfirmed)
                {
                    return RedirectToAction("login", new { invalid = "enc" });
                }
            }
            
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                if(email != null)
                {
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await _userManager.CreateAsync(user);
                    }

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                return View("Error");
            }
        }

        [HttpPost]
        [Route("Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home", new { Area = "Client" });
        }

        async void ProcessEmail(string email,string type,string token,string userId = null)
        {
            var pathToFile = _env.WebRootPath
                    + Path.DirectorySeparatorChar.ToString()
                    + "EmailTemplates"
                    + Path.DirectorySeparatorChar.ToString()
                    + "Email.html";

            string subject, describe, btnText, href;

            if (type == "1")
            {
                
                subject = "Reset password with ";
                describe = "Click this button to reset your password";
                href = Hosting.Name+"/account/resetpassword?email=" + email + "&token=" + token;
                btnText = "Reset Password";
            }
            else
            {
                subject = "Welcome to ";
                describe = "Click this button to confirm email";
                href = Hosting.Name+"/account/confirmemail?userId=" + userId + "&token=" + token;
                btnText = "Confirm";
            }
            
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }
            string htmlBody = builder.HtmlBody
                .Replace("{0}", subject)
                .Replace("{1}", describe)
                .Replace("{2}", href)
                .Replace("{3}", btnText);

            await _emailSender.SendEmailAsync(email, subject + "Xanadu Apple Store", htmlBody);
        }
                
        [Route("SendEmailReset")]
        [HttpPost]
        public async Task<IActionResult> SendEmailReset(string email, string type)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                
                ProcessEmail(email, type,token);

                return Json("success");
            }
            else
            {
                return Json("Email doesn't exist or you never sign up !");
            }
        }

        [Route("Account/ResetPassword")]
        [AllowAnonymous]
        public IActionResult ResetPasswordPage(string email,string token,string confirm)
        {
            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(token))
            {
                ResetPasswordViewModel reset = new ResetPasswordViewModel();
                reset.Email = email;
                reset.Token = token;
                return View(reset);
            }
            else
            {
                if (!string.IsNullOrEmpty(confirm))
                {
                    ResetPasswordViewModel reset = new ResetPasswordViewModel();
                    return View(reset);
                }
                return NotFound();
            }
        }
                
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel reset)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(reset.Email);
                reset.Token = reset.Token.Replace(" ", "+");
                var result = await _userManager.ResetPasswordAsync(user, reset.Token, reset.Password);
            }
            
            return RedirectToAction("ResetPasswordPage","Identity",new { confirm="success"});   
        }        
        
    }
}