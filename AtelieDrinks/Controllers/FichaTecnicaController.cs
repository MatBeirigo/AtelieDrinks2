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
    public class FichaTecnicaController : Controller
    {
        private readonly Contexto _context;

        public FichaTecnicaController(Contexto context)
        {
            _context = context;
        }

        // GET: FichaTecnica
        public async Task<IActionResult> Index()
        {
              return _context.Ficha_tecnica != null ? 
                          View(await _context.Ficha_tecnica.ToListAsync()) :
                          Problem("Entity set 'Contexto.Ficha_tecnica'  is null.");
        }

        // GET: FichaTecnica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ficha_tecnica == null)
            {
                return NotFound();
            }

            var ficha_tecnica = await _context.Ficha_tecnica
                .FirstOrDefaultAsync(m => m.id_ficha == id);
            if (ficha_tecnica == null)
            {
                return NotFound();
            }

            return View(ficha_tecnica);
        }

        // GET: FichaTecnica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FichaTecnica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_ficha,nome_drink,nome_base_alcoolica,nome_insumo,custo_insumo,custo_base_alcoolica,medida,ml_unidade,valor_ficha")] Ficha_tecnica ficha_tecnica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ficha_tecnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ficha_tecnica);
        }

        // GET: FichaTecnica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ficha_tecnica == null)
            {
                return NotFound();
            }

            var ficha_tecnica = await _context.Ficha_tecnica.FindAsync(id);
            if (ficha_tecnica == null)
            {
                return NotFound();
            }
            return View(ficha_tecnica);
        }

        // POST: FichaTecnica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_ficha,nome_drink,nome_base_alcoolica,nome_insumo,custo_insumo,custo_base_alcoolica,medida,ml_unidade,valor_ficha")] Ficha_tecnica ficha_tecnica)
        {
            if (id != ficha_tecnica.id_ficha)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ficha_tecnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ficha_tecnicaExists(ficha_tecnica.id_ficha))
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
            return View(ficha_tecnica);
        }

        // GET: FichaTecnica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ficha_tecnica == null)
            {
                return NotFound();
            }

            var ficha_tecnica = await _context.Ficha_tecnica
                .FirstOrDefaultAsync(m => m.id_ficha == id);
            if (ficha_tecnica == null)
            {
                return NotFound();
            }

            return View(ficha_tecnica);
        }

        // POST: FichaTecnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ficha_tecnica == null)
            {
                return Problem("Entity set 'Contexto.Ficha_tecnica'  is null.");
            }
            var ficha_tecnica = await _context.Ficha_tecnica.FindAsync(id);
            if (ficha_tecnica != null)
            {
                _context.Ficha_tecnica.Remove(ficha_tecnica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Ficha_tecnicaExists(int id)
        {
          return (_context.Ficha_tecnica?.Any(e => e.id_ficha == id)).GetValueOrDefault();
        }
    }
}
