using System.Web.Mvc;
using BancoDeSangre.Services.Email;

namespace BancoDeSangre.Controllers
{
    public class InformationController : Controller
    {
        private IEmailService emailService;
        public InformationController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        /// <summary>
        /// Shows the Contact Information
        /// </summary>
        /// <returns>Contact view</returns>
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AskForInfo(string name, string lastname, string email, string phone, string message)
        {
            var emailToSend = new Email
            {
                From = email,
                To = "contacto.banco.sangre@gmail.com",
                Subject = $"{name} {lastname} nos ha contactado",
                MessageBody = $"{name} {lastname} nos ha contactado.\n" +
                              $"Correo electrónico: {email}\n" +
                              $"Télefono: {phone}\n" +
                              $"Mensaje: {message}"
            };
            emailService.Send(emailToSend);
            return Json(new {done=true});
        }
    }
}