using System.Web.Mvc;
using BancoDeSangre.Models;

namespace BancoDeSangre.Controllers
{
    public class ManagerController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckSignIn(Manager user)
        {
            return new EmptyResult();            
        }

        [HttpGet]
        public ActionResult CreateManager()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveManager(Manager user)
        {
            return new EmptyResult();
        }
    }
}