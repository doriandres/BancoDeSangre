namespace BancoDeSangre.Services.Email
{
    public class Email : IEmail
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
    }
}