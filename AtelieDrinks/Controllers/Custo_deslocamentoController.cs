using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtelieDrinks.Data;
using AtelieDrinks.Models;

namespace AtelieDrinks.Controllers
{
    public class Custo_deslocamentoController : Controller
    {
        private readonly Contexto _context;

        public Custo_deslocamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Custo_deslocamento
        public async Task<IActionResult> Index()
        {
              return _context.Custo_deslocamento != null ? 
                          View(await _context.Custo_deslocamento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Custo_deslocamento'  is null.");
        }

        // GET: Custo_deslocamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Custo_deslocamento == null)
            {
                return NotFound();
            }

            var custo_deslocamento = await _context.Custo_deslocamento
                .FirstOrDefaultAsync(m => m.IdTaxaDeslocamento == id);
            if (custo_deslocamento == null)
            {
                return NotFound();
            }

            return View(custo_deslocamento);
        }

        // GET: Custo_deslocamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Custo_deslocamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTaxaDeslocamento,QtdTipoDeslocamento,ValorTipoDeslocamento,CustoTipoDeslocamento")] Custo_deslocamento custo_deslocamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custo_deslocamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custo_deslocamento);
        }

        // GET: Custo_deslocamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Custo_deslocamento == null)
            {
                return NotFound();
            }

            var custo_deslocamento = await _context.Custo_deslocamento.FindAsync(id);
            if (custo_deslocamento == null)
            {
                return NotFound();
            }
            return View(custo_deslocamento);
        }

        // POST: Custo_deslocamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTaxaDeslocamento,QtdTipoDeslocamento,ValorTipoDeslocamento,CustoTipoDeslocamento")] Custo_deslocamento custo_deslocamento)
        {
            if (id != custo_deslocamento.IdTaxaDeslocamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custo_deslocamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Custo_deslocamentoExists(custo_deslocamento.IdTaxaDeslocamento))
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
            return View(custo_deslocamento);
        }

        // GET: Custo_deslocamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Custo_deslocamento == null)
            {
                return NotFound();
            }

            var custo_deslocamento = await _context.Custo_deslocamento
                .FirstOrDefaultAsync(m => m.IdTaxaDeslocamento == id);
            if (custo_deslocamento == null)
            {
                return NotFound();
            }

            return View(custo_deslocamento);
        }

        // POST: Custo_deslocamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Custo_deslocamento == null)
            {
                return Problem("Entity set 'Contexto.Custo_deslocamento'  is null.");
            }
            var custo_deslocamento = await _context.Custo_deslocamento.FindAsync(id);
            if (custo_deslocamento != null)
            {
                _context.Custo_deslocamento.Remove(custo_deslocamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Custo_deslocamentoExists(int id)
        {
          return (_context.Custo_deslocamento?.Any(e => e.IdTaxaDeslocamento == id)).GetValueOrDefault();
        }
    }
}
