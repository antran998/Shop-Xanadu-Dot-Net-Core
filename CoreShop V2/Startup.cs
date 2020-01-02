using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreShop_V2.Areas.Admin.Models;
using CoreShop_V2.Paypal;
using CoreShop_V2.Service;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Twilio;

namespace CoreShop_V2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddXmlSerializerFormatters();
            
            services.AddAuthentication()
                .AddGoogle(opts =>
                {
                    opts.ClientId = Configuration["Google:ClientId"];
                    opts.ClientSecret = Configuration["Google:ClientSecret"];
                })
                .AddFacebook(opts=>
                {
                    opts.AppId = Configuration["Facebook:AppId"];
                    opts.AppSecret = Configuration["Facebook:AppSecret"];
                });
            services.AddDbContext<MyDbContext>(
                b => b.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("Database")));
            
            services.AddIdentity<ApplicationUser, ApplicationRole>(opts =>
            {
                opts.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<MyDbContext>()
                .AddDefaultTokenProviders(); 
            services.AddSession();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            
            TwilioClient.Init(TwilioService.AccountSID, TwilioService.AuthToken);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{area:exists}/{controller=home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "default",
                    areaName: "Client",
                    template: "{controller=home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "Admin",
                    areaName: "Admin",
                    template: "{controller=home}/{action=Index}/{id?}");
            });

        }
    }
}
