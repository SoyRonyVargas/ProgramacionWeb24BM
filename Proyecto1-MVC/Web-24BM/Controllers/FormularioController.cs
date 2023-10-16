using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_24BM.Services;
using Web_24BM.Models;

namespace Web_24BM.Controllers
{
    public class FormularioController : Controller
    {
        public readonly IEmailSenderService emailSenderService;

        public FormularioController(IEmailSenderService emailSenderService)
        {
            this.emailSenderService = emailSenderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarFullFormulario(EnviarFormularioFull model)
        {
            TempData["EmailT"] = model.email;
            
            TempData["ComentarioT"] = model.comentario;
            
            bool response = this.emailSenderService.SendEmailFull(model);

            Debugger.Break(); // Inicia un punto de interrupción

            TempData["enviado"] = response;
            
            TempData["enviado_email"] = model.email;

            return View("Index");
        }

    }
}
