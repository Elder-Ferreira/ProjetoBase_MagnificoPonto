using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBase_MagnificoPonto.Data;

namespace ProjetoBase_MagnificoPonto.Controllers
{
    public class ListaProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Amigurumis.ToListAsync();

            return View(produtos);
        }
    }
}
