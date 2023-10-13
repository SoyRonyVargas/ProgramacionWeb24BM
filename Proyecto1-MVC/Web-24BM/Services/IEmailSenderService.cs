namespace Web_24BM.Services
{
    public interface IEmailSenderService
    {
        bool SendEmail(string email, string asunto, string comentario);
        void Say(string email);
    }
}
