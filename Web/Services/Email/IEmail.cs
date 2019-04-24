namespace BancoDeSangre.Services.Email
{
    public interface IEmail
    {
        string To { get; set; }
        string From { get; set; }
        string Subject { get; set; }
        string MessageBody { get; set; }
    }
}