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
    public class BaseAlcoolicaController : Controller
    {
        private readonly Contexto _context;

        public BaseAlcoolicaController(Contexto context)
        {
            _context = context;
        }

        // GET: BaseAlcoolica
        public async Task<IActionResult> Index()
        {
              return _context.Base_Alcoolica != null ? 
                          View(await _context.Base_Alcoolica.ToListAsync()) :
                          Problem("Entity set 'Contexto.Base_Alcoolica'  is null.");
        }

        // GET: BaseAlcoolica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Base_Alcoolica == null)
            {
                return NotFound();
            }

            var base_alcoolica = await _context.Base_Alcoolica
                .FirstOrDefaultAsync(m => m.id_base_alcoolica == id);
            if (base_alcoolica == null)
            {
                return NotFound();
            }

            return View(base_alcoolica);
        }

        // GET: BaseAlcoolica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseAlcoolica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_base_alcoolica,quantidade,nome_bebida,nome_marca,custo_garrafa,custo_total")] Base_alcoolica base_alcoolica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(base_alcoolica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(base_alcoolica);
        }

        // GET: BaseAlcoolica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Base_Alcoolica == null)
            {
                return NotFound();
            }

            var base_alcoolica = await _context.Base_Alcoolica.FindAsync(id);
            if (base_alcoolica == null)
            {
                return NotFound();
            }
            return View(base_alcoolica);
        }

        // POST: BaseAlcoolica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_base_alcoolica,quantidade,nome_bebida,nome_marca,custo_garrafa,custo_total")] Base_alcoolica base_alcoolica)
        {
            if (id != base_alcoolica.id_base_alcoolica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(base_alcoolica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Base_alcoolicaExists(base_alcoolica.id_base_alcoolica))
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
            return View(base_alcoolica);
        }

        // GET: BaseAlcoolica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Base_Alcoolica == null)
            {
                return NotFound();
            }

            var base_alcoolica = await _context.Base_Alcoolica
                .FirstOrDefaultAsync(m => m.id_base_alcoolica == id);
            if (base_alcoolica == null)
            {
                return NotFound();
            }

            return View(base_alcoolica);
        }

        // POST: BaseAlcoolica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Base_Alcoolica == null)
            {
                return Problem("Entity set 'Contexto.Base_Alcoolica'  is null.");
            }
            var base_alcoolica = await _context.Base_Alcoolica.FindAsync(id);
            if (base_alcoolica != null)
            {
                _context.Base_Alcoolica.Remove(base_alcoolica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Base_alcoolicaExists(int id)
        {
          return (_context.Base_Alcoolica?.Any(e => e.id_base_alcoolica == id)).GetValueOrDefault();
        }
    }
}
