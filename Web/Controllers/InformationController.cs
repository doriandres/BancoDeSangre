using System.Web.Mvc;

namespace BancoDeSangre.Controllers
{
    public class InformationController : Controller
    {
        /// <summary>
        /// Shows the Contact Information
        /// </summary>
        /// <returns>Contact view</returns>
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}