using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjetoBase_MagnificoPonto.Data;
using ProjetoBase_MagnificoPonto.Models;

namespace ProjetoBase_MagnificoPonto.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProdutosController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoModelDto produtoModelDto)
        {
            if (produtoModelDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile","Insira a imagem");
            }

            if (!ModelState.IsValid)
            {
                return View(produtoModelDto);
            }

            //Salvando ImageFile
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(produtoModelDto.ImageFile!.FileName);

            string imageFullPath = _environment.WebRootPath + "/imgAmigurumis/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                produtoModelDto.ImageFile.CopyTo(stream);
            }

            //Salvar novo produto no banco de dados
            ProdutoModel produto = new ProdutoModel()
            {
                Nome = produtoModelDto.Nome,
                Referencia = produtoModelDto.Referencia,
                Tamanho = produtoModelDto.Tamanho,
                Preco = produtoModelDto.Preco,
                Categoria = produtoModelDto.Categoria,
                Descrição = produtoModelDto.Descrição,
                TempoConfeccao = produtoModelDto.TempoConfeccao,
                ProntaEntrega = produtoModelDto.ProntaEntrega,
                ImageFileName = newFileName,
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "Produtos");

        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produtos.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }
            return View(produtoModel);
        }

        // POST: Produtos/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoModelExists(produtoModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produtoModel);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produtos'  is null.");
            }
            var produtoModel = await _context.Produtos.FindAsync(id);
            if (produtoModel != null)
            {
                _context.Produtos.Remove(produtoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoModelExists(int id)
        {
          return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
