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
        /// Saves a donation to a donor
        /// </summary>
        /// <param name="donation">Donation information to be saved</param>
        /// <param name="donorId">Donor Id</param>
        /// <returns>JSON with result of the operation</returns>
        [HttpPost]
        public ActionResult SaveDonationToDonor(Donation donation, int donorId)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            donation.DonorId = donorId; //Le asigna a la donacion el donador respectivo

            if (!donationService.IsValidDonation(donation, out var cause))
            {
                return Json(new { saved = false, cause });
            }            

            var saved = donationService.CreateDonation(donation);

            return Json(new { saved });
        }

        [HttpGet]
        public ActionResult History()
        {
            var model = new DonationsHistoryViewModel
            {
                Donations = donationService.FindAll()
            };

            return View(model);
        }
    }
}