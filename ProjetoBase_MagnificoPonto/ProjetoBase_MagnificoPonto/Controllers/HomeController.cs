using Microsoft.AspNetCore.Mvc;
using ProjetoBase_MagnificoPonto.Models;
using System.Diagnostics;

namespace ProjetoBase_MagnificoPonto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("HomePage");
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            return View();
        }


        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult Termos()
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
