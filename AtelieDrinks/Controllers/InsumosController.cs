using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtelieDrinks.Data;
using AtelieDrinks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtelieDrinks.Controllers
{
    public class InsumosController : Controller
    {
        private readonly Contexto _context;

        public InsumosController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var insumos = await _context.Insumos.ToListAsync();
            return View(insumos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .FirstOrDefaultAsync(m => m.IdInsumo == id);

            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInsumo,NomeInsumo,QuantidadeInsumo,ValorInsumo")] Insumos insumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insumos);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInsumo,NomeInsumo,QuantidadeInsumo,ValorInsumo")] Insumos insumos)
        {
            if (id != insumos.IdInsumo)
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
                    if (!InsumosExists(insumos.IdInsumo))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .FirstOrDefaultAsync(m => m.IdInsumo == id);

            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insumos = await _context.Insumos.FindAsync(id);
            if (insumos == null)
            {
                return NotFound();
            }

            _context.Insumos.Remove(insumos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsumosExists(int id)
        {
            return _context.Insumos.Any(e => e.IdInsumo == id);
        }
    }
}
