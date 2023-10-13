using System.Net.Mail;
using System.Net;

namespace Web_24BM.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public void Say(string email)
        {

        }

        public bool SendEmail(string email, string asunto, string comentario)
        {
            try
            {
                MailMessage main = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("mail.shapp.mx", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
                main.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                main.Subject = asunto;
                main.To.Add(email);
                main.IsBodyHtml = true;
                main.Body = $"{comentario}";
                smtpClient.Send(main);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
