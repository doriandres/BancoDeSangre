using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DonorService;
using BancoDeSangre.ViewModels.DonorViewModels;

namespace BancoDeSangre.Controllers
{
    public class DonorController : Controller
    {
        private IDonorService donorService;

        public DonorController(IDonorService donorService)
        {
            this.donorService = donorService;
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
        /// Shows the create a donor page
        /// </summary>
        /// <returns>Can only create a donor if Manager is signed in, else is returned to Contact</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (Session.IsSignedIn())
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Creates a donor
        /// </summary>
        /// <param name="donor">Donor information to be saved</param>
        /// <returns>JSON with result of the operation</returns>
        [HttpPost]
        public ActionResult SaveDonor(Donor donor)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            if (!donorService.IsValidDonor(donor, out var cause))
            {
                return Json(new { saved = false, cause });
            }

            var saved = donorService.CreateDonor(donor);
            return Json(new { saved });
        }

        [HttpGet]
        public ActionResult List()
        {
            if (!Session.IsSignedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            
            var model = new DonorListViewModel
            {
                Donors = donorService.FindAll()
            };
            return View(model);
        }
    }
}