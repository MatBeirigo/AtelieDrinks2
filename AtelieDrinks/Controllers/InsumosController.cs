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
    public class InsumosController : Controller
    {
        private readonly Contexto _context;

        public InsumosController(Contexto context)
        {
            _context = context;
        }

        // GET: Insumos
        public async Task<IActionResult> Index()
        {
              return _context.Insumos != null ? 
                          View(await _context.Insumos.ToListAsync()) :
                          Problem("Entity set 'Contexto.Insumos'  is null.");
        }

        // GET: Insumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insumos == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .FirstOrDefaultAsync(m => m.id_insumo == id);
            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        // GET: Insumos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_insumo,nome_insumo,quantidade,custo_insumo")] Insumos insumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insumos);
        }

        // GET: Insumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insumos == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos.FindAsync(id);
            if (insumos == null)
            {
                return NotFound();
            }
            return View(insumos);
        }

        // POST: Insumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_insumo,nome_insumo,quantidade,custo_insumo")] Insumos insumos)
        {
            if (id != insumos.id_insumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsumosExists(insumos.id_insumo))
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
            return View(insumos);
        }

        // GET: Insumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insumos == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .FirstOrDefaultAsync(m => m.id_insumo == id);
            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        // POST: Insumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insumos == null)
            {
                return Problem("Entity set 'Contexto.Insumos'  is null.");
            }
            var insumos = await _context.Insumos.FindAsync(id);
            if (insumos != null)
            {
                _context.Insumos.Remove(insumos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsumosExists(int id)
        {
          return (_context.Insumos?.Any(e => e.id_insumo == id)).GetValueOrDefault();
        }
    }
}
