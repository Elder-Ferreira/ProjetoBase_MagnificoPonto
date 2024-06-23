using Microsoft.AspNetCore.Mvc;

namespace ProjetoBase_MagnificoPonto.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
