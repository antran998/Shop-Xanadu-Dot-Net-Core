using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShop_V2.Service;
using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MailChimpMgnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateMailCampaign")]
        public IActionResult CreateCampaign(string ReplyTo, string FromName, string Title, string SubjectLine)
        {
            MailChimpManager _mailChimpManager = new MailChimpManager(MailChimpService.MailSid);
            Setting _campaignSettings = new Setting
            {
                ReplyTo = ReplyTo,
                FromName = FromName,
                Title = Title,
                SubjectLine = SubjectLine,
            };
            var campaign = _mailChimpManager.Campaigns.AddAsync(new Campaign
            {

                Settings = _campaignSettings,
                Recipients = new Recipient { ListId = MailChimpService.MailListId },
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
            return Json("success");
        }

    }
}