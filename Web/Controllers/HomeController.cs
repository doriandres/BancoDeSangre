using System.Web.Mvc;

namespace BancoDeSangre.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //using (var db = new DataBaseService())
            //{
            //    var model = new HomeViewModel
            //    {
            //        Campaigns = db.Campaigns
            //            .Where(c => DateTime.Today <= c.Date)
            //            .OrderBy(c => c.Date)
            //            .ThenBy(c => c.StartTime)
            //            .ToList()
            //    };

                return View();
            //}
        }
    }
}