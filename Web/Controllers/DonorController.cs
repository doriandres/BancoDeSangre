using System.Web.Mvc;
using BancoDeSangre.Models;

namespace BancoDeSangre.Controllers
{
    public class DonorController : Controller
    {
        [HttpGet]
        public ActionResult Register(Donor donor)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Donor donor)
        {
            return new EmptyResult();
        }
    }
}