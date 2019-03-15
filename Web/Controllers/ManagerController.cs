using System.Web.Mvc;
using BancoDeSangre.App_Data;
using BancoDeSangre.Models;
using BancoDeSangre.Services.ManagerService;

namespace BancoDeSangre.Controllers
{
    public class ManagerController : Controller
    {
        private IManagerService managerService;

        public ManagerController(IManagerService managerService)
        {
            this.managerService = managerService;
        }

        /// <summary>
        /// Shows the Sign In page
        /// </summary>
        /// <returns>If the user is not signed in show the sign in page else redirects to the home page</returns>
        [HttpGet]
        public ActionResult SignIn()
        {
            if (!Session.IsSignedIn()) // If there's not signed in manager show sign in page
            {
                return View();
            }

            // If the user is already signed in redirect to the home page
            return RedirectToAction("Index", "Home");

        }

        /// <summary>
        /// Shows the Sign In page
        /// </summary>
        /// <returns>If the user is not signed in show the sign in page else redirects to the home page</returns>
        [HttpGet]
        public ActionResult SignOut()
        {
            Session.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Checks the Sign In credentials
        /// </summary>
        /// <param name="email">Email intended to sign in</param>
        /// <param name="password">Password to sign in</param>
        /// <returns>Whether the credential or the session status is valid or not</returns>
        [HttpPost]
        public JsonResult CheckSignIn(string email, string password)
        {
            var valid = false;
            var cause = "";

            /**
             * First check if the user has not signed in yet
             * They can't access the sign in page if they have already signed in
             * but they can open twice the sign in page to sign in from one of them
             * and then turn their tab and try to sign in again
             */
            if (!Session.IsSignedIn()) 
            {
                // Try to find any manager matching the email

                var manager = managerService.FindManagerByEmail(email);

                // The procedure is going to be valid only if any manager was found and its password matches the given password
                valid = manager != null && manager.Password == password;

                if (valid)
                {
                    // Set the Session Signed In Manager
                    Session.SetSignedInManager(manager);                    
                }
                else
                {
                    if (manager == null)
                    {
                        cause = "Email no existe";
                    }
                    else
                    {
                        cause = "Credenciales inválidas";
                    }
                }
            }
            else
            {
                cause = "Ya hay una sesión iniciada";
            }
            return Json(new { valid, cause });

        }

        /// <summary>
        /// Show the create manager page
        /// </summary>
        /// <returns>If the user is already signed in show the page else redirects to the homepage</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (Session.IsSignedIn()) // Only signed in Managers can create Managers
            {
                return View();

            }
            // If there's no signed in manager redirect to home page
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Saves a manager
        /// </summary>
        /// <param name="manager">Manager info to save</param>
        /// <returns>JSON response with the process results</returns>
        [HttpPost]
        public ActionResult SaveManager(Manager manager)
        {
            if (!Session.IsSignedIn()) // Only a signed in manager can Save Managers
            {
                return Json(new { saved = false });
            }

            if (managerService.FindManagerByEmail(manager.Email) != null) // Handle existing email response
            {
                return Json(new { saved = false, cause = "El email ya existe" });
            }
                
            var result = managerService.CreateManager(manager);

            return Json(new { saved = result });            
        }
    }
}