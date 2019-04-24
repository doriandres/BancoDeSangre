using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.BloodRequestService;
using BancoDeSangre.ViewModels.BloodRequestViewModels;

namespace BancoDeSangre.Controllers
{
    public class BloodRequestController : Controller
    {
        private IBloodRequestService bloodRequestService;

        public BloodRequestController(IBloodRequestService bloodRequestService)
        {
            this.bloodRequestService = bloodRequestService;
        }

        /// <summary>
        /// Creates a blood request
        /// </summary>
        /// <param name="bloodRequest">Blood request information to be saved</param>
        /// <returns>JSON with result of the operation</returns>
        [HttpGet]
        public ActionResult Menu()
        {
            if (Session.IsSignedIn())
            {
                return View();

            }
            // If there's no signed in manager redirect to home page
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Session.IsSignedIn())
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Saves a blood request
        /// </summary>
        /// <param name="bloodRequest">Blood request information to be saved</param>
        /// <returns>JSON with result of the operation</returns>
        [HttpPost]
        public ActionResult SaveBloodRequest(BloodRequest bloodRequest)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            if (!bloodRequestService.IsValid(bloodRequest, out var cause))
            {
                return Json(new { saved = false, cause });
            }

            var saved = bloodRequestService.CreateBloodRequest(bloodRequest);
            return Json(new { saved });
        }

        [HttpGet]
        public ActionResult List()
        {
            if (!Session.IsSignedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new BloodRequestListViewModel
            {
                BloodRequests = bloodRequestService.FindAll()
            };
            return View(model);
        }
    }
}