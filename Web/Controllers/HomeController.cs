using System;
using System.Linq;
using System.Web.Mvc;
using BancoDeSangre.Services.DB;
using BancoDeSangre.ViewModels.Home;

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