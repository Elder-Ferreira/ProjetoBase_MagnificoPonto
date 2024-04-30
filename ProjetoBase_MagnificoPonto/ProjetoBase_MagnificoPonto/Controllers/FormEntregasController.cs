using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBase_MagnificoPonto.Data;
using ProjetoBase_MagnificoPonto.Models;

namespace ProjetoBase_MagnificoPonto.Controllers
{
    public class FormEntregasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormEntregasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormEntregas
        public async Task<IActionResult> Index()
        {
              return View(await _context.FormEntregas.ToListAsync());
        }

        // GET: FormEntregas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormEntregas == null)
            {
                return NotFound();
            }

            var formEntregaModel = await _context.FormEntregas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formEntregaModel == null)
            {
                return NotFound();
            }

            return View(formEntregaModel);
        }

        // GET: FormEntregas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormEntregas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,Rua,Numero,Bairro,Cep,Referencia,Criacao")] FormEntregaModel formEntregaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formEntregaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formEntregaModel);
        }

        // GET: FormEntregas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormEntregas == null)
            {
                return NotFound();
            }

            var formEntregaModel = await _context.FormEntregas.FindAsync(id);
            if (formEntregaModel == null)
            {
                return NotFound();
            }
            return View(formEntregaModel);
        }

        // POST: FormEntregas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telefone,Rua,Numero,Bairro,Cep,Referencia,Criacao")] FormEntregaModel formEntregaModel)
        {
            if (id != formEntregaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formEntregaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormEntregaModelExists(formEntregaModel.Id))
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
            return View(formEntregaModel);
        }

        // GET: FormEntregas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormEntregas == null)
            {
                return NotFound();
            }

            var formEntregaModel = await _context.FormEntregas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formEntregaModel == null)
            {
                return NotFound();
            }

            return View(formEntregaModel);
        }

        // POST: FormEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormEntregas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FormEntregas'  is null.");
            }
            var formEntregaModel = await _context.FormEntregas.FindAsync(id);
            if (formEntregaModel != null)
            {
                _context.FormEntregas.Remove(formEntregaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormEntregaModelExists(int id)
        {
          return _context.FormEntregas.Any(e => e.Id == id);
        }
    }
}
