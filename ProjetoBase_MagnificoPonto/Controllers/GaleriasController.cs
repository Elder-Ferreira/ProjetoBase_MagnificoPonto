using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBase_MagnificoPonto.Data;

namespace ProjetoBase_MagnificoPonto.Controllers
{
    public class GaleriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GaleriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Galerias.ToListAsync();

            return View(dados);
        }
    }
}
