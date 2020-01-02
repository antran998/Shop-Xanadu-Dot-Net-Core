using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreShop_V2.Areas.Client.Controllers
{
    [Area("Client")]
    public class MailChimpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCampaign()
        {
            MailChimpManager _mailChimpManager = new MailChimpManager("7b6eca284d892915d0c10bd48b0a28cb-us5");
            Setting _campaignSettings = new Setting
            {
                ReplyTo = "hienkwan@gmail.com",
                FromName = "CoreShop",
                Title = "Intro new product",
                SubjectLine = "Introduction",
            };
            var campaign = _mailChimpManager.Campaigns.AddAsync(new Campaign
            {

                Settings = _campaignSettings,
                Recipients = new Recipient { ListId = "206aea1391" },
                Type = CampaignType.Regular
            }).Result;
            var timeStr = DateTime.Now.ToString();
            var content = _mailChimpManager.Content.AddOrUpdateAsync(
             campaign.Id,
             new ContentRequest()
             {
                 Template = new ContentTemplate
                 {
                     Id = 248261,
                 }
             }).Result;
            _mailChimpManager.Campaigns.SendAsync(campaign.Id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("MailchimpRegister")]
        public IActionResult RegisterEmail()
        {

            return PartialView();
        }
    }
}