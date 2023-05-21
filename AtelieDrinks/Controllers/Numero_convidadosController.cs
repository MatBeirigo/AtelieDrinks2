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
    public class Numero_convidadosController : Controller
    {
        private readonly Contexto _context;

        public Numero_convidadosController(Contexto context)
        {
            _context = context;
        }

        // GET: Numero_convidados
        public async Task<IActionResult> Index()
        {
              return _context.Numero_convidados != null ? 
                          View(await _context.Numero_convidados.ToListAsync()) :
                          Problem("Entity set 'Contexto.Numero_convidados'  is null.");
        }

        // GET: Numero_convidados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Numero_convidados == null)
            {
                return NotFound();
            }

            var numero_convidados = await _context.Numero_convidados
                .FirstOrDefaultAsync(m => m.id_orcamento == id);
            if (numero_convidados == null)
            {
                return NotFound();
            }

            return View(numero_convidados);
        }

        // GET: Numero_convidados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numero_convidados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_orcamento,numero_pessoas")] Numero_convidados numero_convidados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numero_convidados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numero_convidados);
        }

        // GET: Numero_convidados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Numero_convidados == null)
            {
                return NotFound();
            }

            var numero_convidados = await _context.Numero_convidados.FindAsync(id);
            if (numero_convidados == null)
            {
                return NotFound();
            }
            return View(numero_convidados);
        }

        // POST: Numero_convidados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_orcamento,numero_pessoas")] Numero_convidados numero_convidados)
        {
            if (id != numero_convidados.id_orcamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numero_convidados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Numero_convidadosExists(numero_convidados.id_orcamento))
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
            return View(numero_convidados);
        }

        // GET: Numero_convidados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Numero_convidados == null)
            {
                return NotFound();
            }

            var numero_convidados = await _context.Numero_convidados
                .FirstOrDefaultAsync(m => m.id_orcamento == id);
            if (numero_convidados == null)
            {
                return NotFound();
            }

            return View(numero_convidados);
        }

        // POST: Numero_convidados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Numero_convidados == null)
            {
                return Problem("Entity set 'Contexto.Numero_convidados'  is null.");
            }
            var numero_convidados = await _context.Numero_convidados.FindAsync(id);
            if (numero_convidados != null)
            {
                _context.Numero_convidados.Remove(numero_convidados);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Numero_convidadosExists(int id)
        {
          return (_context.Numero_convidados?.Any(e => e.id_orcamento == id)).GetValueOrDefault();
        }
    }
}
