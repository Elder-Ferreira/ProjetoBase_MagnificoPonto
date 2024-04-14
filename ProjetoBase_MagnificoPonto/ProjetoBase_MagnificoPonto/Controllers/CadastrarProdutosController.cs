using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBase_MagnificoPonto.Data;
using ProjetoBase_MagnificoPonto.Models;
using SQLitePCL;

namespace ProjetoBase_MagnificoPonto.Controllers
{
    public class CadastrarProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CadastrarProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Produtos.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();                     
                

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();
            

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProdutoModel produto)
        {
            if (id != produto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)          
                return NotFound();      

            var dados = await _context.Produtos.FindAsync(Id);

            if (dados == null)          
                return NotFound();            

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(Id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            if (Id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(Id);

            if (dados == null)
                return NotFound();

            _context.Produtos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}



