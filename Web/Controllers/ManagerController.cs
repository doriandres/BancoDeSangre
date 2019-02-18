using System.Linq;
using System.Web.Mvc;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Controllers
{
    public class ManagerController : Controller
    {
        /// <summary>
        /// Shows the Sign In page
        /// </summary>
        /// <returns>If the user is not signed in show the sign in page else redirects to the home page</returns>
        [HttpGet]
        public ActionResult SignIn()
        {
            return Session["manager"] == null ? (ActionResult) View() : RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Shows the Sign In page
        /// </summary>
        /// <returns>If the user is not signed in show the sign in page else redirects to the home page</returns>
        [HttpGet]
        public ActionResult SignOut()
        {
            Session["manager"] = null;
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
            using (var db = new DataBaseService())
            {
                var valid = false;
                var cause = "";
                if (Session["manager"] == null)
                {
                    var manager = db.Managers.FirstOrDefault(m => m.Email == email);
                    valid = manager != null && manager.Password == password;

                    if (!valid)
                    {
                        cause = manager == null ? "Email no existe" : "Credenciales inválidas";
                    }
                    else
                    {
                        Session["manager"] = manager;
                    }
                }
                else
                {
                    cause = "Ya hay una sesión iniciada";
                }                
                return Json(new {valid, cause});
            }            
        }

        /// <summary>
        /// Show the create manager page
        /// </summary>
        /// <returns>If the user is already signed in show the page else redirects to the homepage</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return Session["manager"] == null ?  RedirectToAction("Index", "Home") : (ActionResult)View();
        }

        /// <summary>
        /// Saves a manager
        /// </summary>
        /// <param name="manager">Manager info to save</param>
        /// <returns>JSON response with the process results</returns>
        [HttpPost]
        public ActionResult SaveManager(Manager manager)
        {
            if(Session["manager"] != null) return Json(new { saved = false });
            using (var db = new DataBaseService())
            {
                if (db.Managers.Any(m => m.Email == manager.Email))
                {
                    return Json(new { saved = false, cause = "El email ya existe" });
                }                    
                db.Managers.Add(manager);
                var count = db.SaveChanges();
                return Json(new { saved = count > 0 });
            }
        }
    }
}