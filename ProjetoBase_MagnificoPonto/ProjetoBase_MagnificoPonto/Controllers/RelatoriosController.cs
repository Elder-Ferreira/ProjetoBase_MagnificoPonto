﻿using System;
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
    public class RelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Relatorios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Relatorios.ToListAsync());
        }

        // GET: Relatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Relatorios == null)
            {
                return NotFound();
            }

            var relatorioModel = await _context.Relatorios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioModel == null)
            {
                return NotFound();
            }

            return View(relatorioModel);
        }

        // GET: Relatorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,Cor,Tamanho,Preco,Categoria,Descrição,TempoConfeccao,ProntaEntrega,PlataformaVenda,DataVenda")] RelatorioModel relatorioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorioModel);
        }

        // GET: Relatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Relatorios == null)
            {
                return NotFound();
            }

            var relatorioModel = await _context.Relatorios.FindAsync(id);
            if (relatorioModel == null)
            {
                return NotFound();
            }
            return View(relatorioModel);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Quantidade,Cor,Tamanho,Preco,Categoria,Descrição,TempoConfeccao,ProntaEntrega,PlataformaVenda,DataVenda")] RelatorioModel relatorioModel)
        {
            if (id != relatorioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioModelExists(relatorioModel.Id))
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
            return View(relatorioModel);
        }

        // GET: Relatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Relatorios == null)
            {
                return NotFound();
            }

            var relatorioModel = await _context.Relatorios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioModel == null)
            {
                return NotFound();
            }

            return View(relatorioModel);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Relatorios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Relatorios'  is null.");
            }
            var relatorioModel = await _context.Relatorios.FindAsync(id);
            if (relatorioModel != null)
            {
                _context.Relatorios.Remove(relatorioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioModelExists(int id)
        {
          return _context.Relatorios.Any(e => e.Id == id);
        }
    }
}
