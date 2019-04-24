namespace BancoDeSangre.Services.Email
{
    public interface IEmailService
    {
        void Send(IEmail email);
    }
}