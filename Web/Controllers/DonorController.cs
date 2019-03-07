using System;
using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.DonorService;

namespace BancoDeSangre.Controllers
{
    public class DonorController : Controller
    {
        private IDonorService donorService;
        public DonorController()
        {
            var dataBaseService = new DataBaseService();
            donorService = new DonorDBService(dataBaseService);
        }

        /// <summary>
        /// Shows the create a donor page
        /// </summary>
        /// <returns>Can only create a donor if Manager is signed in, else is returned to Index</returns>
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
        public ActionResult Save(Donor donor)
        {
            if (!Session.IsSignedIn())
            {
                return Json(new { saved = false });
            }

            using (var db = new DataBaseService())
            {
                var valid = true;
                var cause = "";

                if (donor.Name.Trim().Length == 0)
                {
                    cause = "Debe ingresar un nombre";
                    valid = false;
                }

                if (donor.LastName.Trim().Length == 0)
                {
                    cause = "Debe ingresar un apellido";
                    valid = false;
                }

                if (donor.PhoneNumber < 20000000)
                {
                    cause = "Debe ingresar un n\u00famero de tel\u00E9fono v\u00E1lido";
                    valid = false;
                }

                if ((DateTime.Today.Year - donor.BornDate.Year) < 18)
                {
                    cause = "No puede recibir donaciones de menores de edad";
                    valid = false;
                }

                if (donor.Email.Trim().Length == 0)
                {
                    cause = "Debe ingresar un correo";
                    valid = false;
                }

                if (donor.Gender.Trim().Length == 0)
                {
                    cause = "Debe ingresar un g\u00E9nero";
                    valid = false;
                }

                if (donor.Height < 0)
                {
                    cause = "Debe ingresar una altura v\u00e1lida";
                    valid = false;
                }

                if (donor.Weight < 50)
                {
                    cause = "No se permiten donaciones en pacientes con pesos menores a 50 kg";
                    valid = false;
                }

                if (!valid) return Json(new { saved = false, cause });

                db.Donors.Add(donor);
                var count = db.SaveChanges();
                return Json(new { saved = count > 0 });
            }
        }
    }
}