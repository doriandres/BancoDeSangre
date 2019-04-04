using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Controllers
{
    public class MedicalCenterController : Controller
    {

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
        /// Creates a medical center
        /// </summary>
        /// <param name="medicalCenter">Medical center information to be saved</param>
        /// <returns>JSON with result of the operation</returns>
        [HttpPost]
        public ActionResult SaveMedicalCenter(MedicalCenter medicalCenter)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            using (var db = new DataBaseService())
            {
                var valid = true;
                var cause = "";

                if (medicalCenter.Name.Trim().Length == 0)
                {
                    cause = "Debe ingresar un nombre";
                    valid = false;
                }

                if (medicalCenter.Email.Trim().Length == 0)
                {
                    cause = "Debe ingresar un correo";
                    valid = false;
                }

                if (medicalCenter.PhoneNumber < 20000000)
                {
                    cause = "Debe ingresar un n\u00famero de tel\u00E9fono v\u00E1lido";
                    valid = false;
                }

                if (medicalCenter.Place.Trim().Length == 0)
                {
                    cause = "Debe ingresar una localizaci\u00e9n";
                    valid = false;
                }

                db.MedicalCenters.Add(medicalCenter);
                var count = db.SaveChanges();
                return Json(new { saved = count > 0 });
            }
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
    }
}