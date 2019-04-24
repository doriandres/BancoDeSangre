namespace BancoDeSangre.Services.Email
{
    public interface IEmailService
    {
        string AppEmail { get; }
        void Send(IEmail email);
    }
}