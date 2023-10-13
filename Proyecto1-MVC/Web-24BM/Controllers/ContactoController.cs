using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Web_24BM.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EnviarEmail(string email, string comentario)
        {
            TempData["EmailT"] = email;
            TempData["ComentarioT"] = comentario;
            EnviarEmailSmtp(email);
            return View("Index","contacto");
        }

        public bool EnviarEmailSmtp(string email)
        {
            MailMessage main = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.shapp.mx", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dharserck_999");
            main.From = new MailAddress("moises.puc@shapp.mx","administrador");
            main.To.Add(email);
            main.IsBodyHtml = true;
            main.Body= $"se ha contactado la persona con el correo {email} para solicitar informacion";
            smtpClient.Send(main);
            return true; 
        }
    }
}
