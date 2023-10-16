using Web_24BM.Models;

namespace Web_24BM.Services
{
    public interface IEmailSenderService
    {
        bool SendEmail(string email, string asunto, string comentario);
        bool SendEmailFull(EnviarFormularioFull formulario);
    }
}
