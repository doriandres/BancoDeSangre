using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.MedicalCenterService;
using BancoDeSangre.ViewModels.MedicalCenterViewModels;

namespace BancoDeSangre.Controllers
{
    public class MedicalCenterController : Controller
    {
        private IMedicalCenterService medicalCenterService;

        public MedicalCenterController(IMedicalCenterService medicalCenterService)
        {
            this.medicalCenterService = medicalCenterService;
        }

        /// <summary>
        /// Creates a medical center
        /// </summary>
        /// <param name="medicalCenter">Medical center information to be saved</param>
        /// <returns>JSON with result of the operation</returns>
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

        [HttpGet]
        public ActionResult Register()
        {
            if (Session.IsSignedIn()) // Only signed in Managers can create Medical Centers
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Creates a medical center
        /// </summary>
        /// <param name="donor">Medical Center information to be saved</param>
        /// <returns>JSON with result of the operation</returns>
        [HttpPost]
        public ActionResult SaveMedicalCenter(MedicalCenter medicalCenter)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            if (!medicalCenterService.IsValid(medicalCenter, out var cause))
            {
                return Json(new { saved = false, cause });
            }

            var saved = medicalCenterService.CreateMedicalCenter(medicalCenter);
            return Json(new { saved });
        }

        [HttpGet]
        public ActionResult List()
        {
            if (!Session.IsSignedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new MedicalCenterListViewModel
            {
                MedicalCenters = medicalCenterService.FindAll()
            };
            return View(model);
        }
    }
}