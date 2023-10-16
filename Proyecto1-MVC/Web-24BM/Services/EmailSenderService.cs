// using System.Diagnostigs;
using System.Net.Mail;
using System.Net;
using Web_24BM.Models;
using System.Diagnostics;


namespace Web_24BM.Services
{
    public class EmailSenderService : IEmailSenderService   
    {

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

        public bool SendEmailFull(EnviarFormularioFull formulario)
        {
            try
            {
                
                MailMessage main = new MailMessage();
                
                SmtpClient smtpClient = new SmtpClient("mail.shapp.mx", 587);
                
                smtpClient.EnableSsl = true;
                
                smtpClient.UseDefaultCredentials = false;
                
                smtpClient.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
                
                main.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                
                main.Subject = formulario.asunto;
                
                main.To.Add(formulario.email);
                
                main.IsBodyHtml = true;
                
                string emailBody = $@"
                    Nombre              : {formulario.nombre} <br>
                    Apellidos           : {formulario.apellidos} <br>
                    Fecha de nacimiento : {formulario.fecha_nacimiento} <br>
                    Hora de entrada     : {formulario.hora_entrada} <br>
                    Turno               : {formulario.turno} <br>
                    Comentarios:
                    { formulario.comentario }
                ";

                Debugger.Break();

                main.Body = emailBody;

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
