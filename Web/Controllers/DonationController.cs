using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DonationService;
using BancoDeSangre.ViewModels.DonationViewModels;

namespace BancoDeSangre.Controllers
{
    public class DonationController : Controller
    {
        private IDonationService donationService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="donationService"></param>
        public DonationController(IDonationService donationService)
        {
            this.donationService = donationService;
        }
        [HttpGet]
        public ActionResult Menu()
        {
            if (Session.IsSignedIn()) // Only signed in Managers can create Managers
            {
                return View();

            }
            // If there's no signed in manager redirect to home page
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Show the create donation page
        /// </summary>
        /// <returns>Register donation page only if user is signed in else redirects to home page</returns>
        [HttpGet]
        public ActionResult Register()
        {
            if (Session.IsSignedIn()) // Only signed in Managers can create donations
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Saves a donation to a donor
        /// </summary>
        /// <param name="donation">Donation information to be saved</param>
        /// <param name="donorId">Donor Id</param>
        /// <returns>JSON with result of the operation</returns>
        [HttpPost]
        public ActionResult Save(Donation donation, int donorId)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            if (!donationService.IsValidDonation(donation, out var cause))
            {
                return Json(new { saved = false, cause = cause });
            }
            else
            {
                var saved = donationService.CreateDonation(donation);

                return Json(new { saved });
            }
        }

        /// <summary>
        /// Displays all donations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            if (!Session.IsSignedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new DonationsListViewModel
            {
                Donations = donationService.FindAll()
            };

            return View(model);
        }
    }
}