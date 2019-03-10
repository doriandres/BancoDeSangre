using System;
using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Controllers
{
    public class CampaignController : Controller
    {
        /// <summary>
        /// Show the create campaign page
        /// </summary>
        /// <returns>Create campaign page only if user is signed in else redirects to home page</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (Session.IsSignedIn()) // Only signed in Managers can create Campaigns
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Saves a campaign
        /// </summary>
        /// <param name="campaign">Campaign information</param>
        /// <returns>Validates the information in order to save it or not and returns the result in a JSON</returns>
        [HttpPost]
        public ActionResult Save(Campaign campaign)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            using (var db = new DataBaseService())
            {
                var valid = true;
                var cause = "";

                if (campaign.Date < DateTime.Today)
                {
                    cause = "La fecha seleccionada ya pasó";
                    valid = false;
                }

                if (campaign.Date == DateTime.Today && campaign.StartTime < DateTime.Now)
                {
                    cause = "La hora de inicio es antes que la hora actual";
                    valid = false;
                }
                if (campaign.EndTime < campaign.StartTime)
                {
                    cause = "La hora de finalización es antes que la hora de inicio";
                    valid = false;
                }

                if (!valid) return Json(new {saved = false, cause});

                campaign.ManagerId = ((Manager) Session["manager"]).Id;
                db.Campaigns.Add(campaign);
                var count = db.SaveChanges();
                return Json(new { saved = count > 0 });
            }
        }
    }
}