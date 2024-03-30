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
    public class AmigurumisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmigurumisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Amigurumis
        public async Task<IActionResult> Index()
        {
              return View(await _context.Amigurumis.ToListAsync());
        }

        // GET: Amigurumis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Amigurumis == null)
            {
                return NotFound();
            }

            var amigurumi = await _context.Amigurumis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amigurumi == null)
            {
                return NotFound();
            }

            return View(amigurumi);
        }

        // GET: Amigurumis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amigurumis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Referencia,Cor,Preco,Categoria,Descrição,ProntaEntrega,TempoConfeccao")] Amigurumi amigurumi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amigurumi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amigurumi);
        }

        // GET: Amigurumis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amigurumis == null)
            {
                return NotFound();
            }

            var amigurumi = await _context.Amigurumis.FindAsync(id);
            if (amigurumi == null)
            {
                return NotFound();
            }
            return View(amigurumi);
        }

        // POST: Amigurumis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Referencia,Cor,Preco,Categoria,Descrição,ProntaEntrega,TempoConfeccao")] Amigurumi amigurumi)
        {
            if (id != amigurumi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amigurumi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmigurumiExists(amigurumi.Id))
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
            return View(amigurumi);
        }

        // GET: Amigurumis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amigurumis == null)
            {
                return NotFound();
            }

            var amigurumi = await _context.Amigurumis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amigurumi == null)
            {
                return NotFound();
            }

            return View(amigurumi);
        }

        // POST: Amigurumis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amigurumis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Amigurumis'  is null.");
            }
            var amigurumi = await _context.Amigurumis.FindAsync(id);
            if (amigurumi != null)
            {
                _context.Amigurumis.Remove(amigurumi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmigurumiExists(int id)
        {
          return _context.Amigurumis.Any(e => e.Id == id);
        }
    }
}
