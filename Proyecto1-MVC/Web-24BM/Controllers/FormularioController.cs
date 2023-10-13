using Microsoft.AspNetCore.Mvc;
using Web_24BM.Services;

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
    }
}
