using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.CampaignService;
using BancoDeSangre.ViewModels.CampaignViewModels;

namespace BancoDeSangre.Controllers
{
    public class CampaignController : Controller
    {
        private ICampaignService campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }


        /// <summary>
        /// Show the Campaigns menu
        /// </summary>
        /// <returns>Create campaigns menu page only if user is signed in else redirects to home page</returns>
        [HttpGet]
        public ActionResult Menu()
        {
            if (Session.IsSignedIn()) // Only signed in Managers can create Campaigns
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

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

            campaign.ManagerId = Session.GetSignedInManager().Id;

            if (!campaignService.IsValidCampaign(campaign, out var cause))
            {
                return Json(new { saved = false, cause });
            }
            else
            {
                var saved = campaignService.CreateCampaign(campaign);

                return Json(new { saved });
            }                      
        }

        /// <summary>
        /// Shows the list of Campaigns
        /// </summary>
        /// <returns>List of campaigns view</returns>
        [HttpGet]
        public ActionResult List()
        {
            var campaigns = campaignService.FindAll();
            var campaignListViewModel = new CampaignListViewModel();
            campaignListViewModel.Campaigns = campaigns;
            return View(campaignListViewModel);
        }
    }
}