using System.Web.Mvc;
using BancoDeSangre.Models;

namespace BancoDeSangre.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckSignIn(User user)
        {            
            return Json(new { result = (user.Email == "hola" && user.Password == "123") });
        }
    }
}