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
    public class CustoDeslocamentoController : Controller
    {
        private readonly Contexto _context;

        public CustoDeslocamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: CustoDeslocamento
        public async Task<IActionResult> Index()
        {
              return _context.Custo_Deslocamento != null ? 
                          View(await _context.Custo_Deslocamento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Custo_Deslocamento'  is null.");
        }

        // GET: CustoDeslocamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Custo_Deslocamento == null)
            {
                return NotFound();
            }

            var custo_deslocamento = await _context.Custo_Deslocamento
                .FirstOrDefaultAsync(m => m.id_taxa_deslocamento == id);
            if (custo_deslocamento == null)
            {
                return NotFound();
            }

            return View(custo_deslocamento);
        }

        // GET: CustoDeslocamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustoDeslocamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_taxa_deslocamento,tipo_deslocamento,valor_tipo_deslocamento,custo_tipo_deslocamento")] Custo_deslocamento custo_deslocamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custo_deslocamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custo_deslocamento);
        }

        // GET: CustoDeslocamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Custo_Deslocamento == null)
            {
                return NotFound();
            }

            var custo_deslocamento = await _context.Custo_Deslocamento.FindAsync(id);
            if (custo_deslocamento == null)
            {
                return NotFound();
            }
            return View(custo_deslocamento);
        }

        // POST: CustoDeslocamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_taxa_deslocamento,tipo_deslocamento,valor_tipo_deslocamento,custo_tipo_deslocamento")] Custo_deslocamento custo_deslocamento)
        {
            if (id != custo_deslocamento.id_taxa_deslocamento)
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
                    if (!Custo_deslocamentoExists(custo_deslocamento.id_taxa_deslocamento))
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

        // GET: CustoDeslocamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Custo_Deslocamento == null)
            {
                return NotFound();
            }

            var custo_deslocamento = await _context.Custo_Deslocamento
                .FirstOrDefaultAsync(m => m.id_taxa_deslocamento == id);
            if (custo_deslocamento == null)
            {
                return NotFound();
            }

            return View(custo_deslocamento);
        }

        // POST: CustoDeslocamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Custo_Deslocamento == null)
            {
                return Problem("Entity set 'Contexto.Custo_Deslocamento'  is null.");
            }
            var custo_deslocamento = await _context.Custo_Deslocamento.FindAsync(id);
            if (custo_deslocamento != null)
            {
                _context.Custo_Deslocamento.Remove(custo_deslocamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Custo_deslocamentoExists(int id)
        {
          return (_context.Custo_Deslocamento?.Any(e => e.id_taxa_deslocamento == id)).GetValueOrDefault();
        }
    }
}
