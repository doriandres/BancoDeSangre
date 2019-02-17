using System.Web.Mvc;
using BancoDeSangre.Models;

namespace BancoDeSangre.Controllers
{
    public class CampaignController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Campaign campaign)
        {
            return new EmptyResult();
        }
    }
}