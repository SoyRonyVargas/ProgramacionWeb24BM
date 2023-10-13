using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Web_24BM.Models;
using Web_24BM.Services;

namespace Web_24BM.Controllers
{
    public class ContactoController : Controller
    {
        public IEmailSenderService emailSenderService;

        public ContactoController(IEmailSenderService emailSenderService)
        {
            this.emailSenderService = emailSenderService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult EnviarEmail(string email, string comentario)
        {
            Debugger.Break();
            TempData["EmailT"] = email;
            TempData["ComentarioT"] = comentario;
            //EnviarEmailSmtp(email);
            return View("Index","contacto");
        }

        [HttpPost]
        public IActionResult EnviarFormulario(EnviarFormulario model)
        {
            TempData["EmailT"] = model.email;
            
            TempData["ComentarioT"] = model.comentario;
            
            bool response = this.emailSenderService.SendEmail(model.email , model.asunto , model.comentario);

            TempData["enviado"] = response;

            return View("Index");

        }

        public bool EnviarEmailSmtp(string email , string asunto , string comentario)
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
