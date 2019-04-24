using System.Net;
using System.Net.Mail;

namespace BancoDeSangre.Services.Email
{
    public class EmailService : IEmailService
    {
        public string AppEmail => "contacto.banco.sangre@gmail.com";
        public void Send(IEmail email)
        {
            var mail = new MailMessage(email.From, email.To, email.Subject, email.MessageBody);            
            var client = new SmtpClient
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential(AppEmail, "googlebancosangre")
            };            

            client.Send(mail);
        }
    }
}