using GestorPaciente.WebApp.Sistema.Middleware;
using GestorPaciente.WebApp.Sistema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestorPaciente.WebApp.Sistema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidationUser _validation;

        public HomeController(ILogger<HomeController> logger, ValidationUser validate)
        {
            _logger = logger;
            _validation = validate;
        }


        public IActionResult Index()
        {

            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
