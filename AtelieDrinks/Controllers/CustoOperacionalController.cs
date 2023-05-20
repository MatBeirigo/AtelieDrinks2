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
    public class CustoOperacionalController : Controller
    {
        private readonly Contexto _context;

        public CustoOperacionalController(Contexto context)
        {
            _context = context;
        }

        // GET: CustoOperacional
        public async Task<IActionResult> Index()
        {
              return _context.Custo_operacional != null ? 
                          View(await _context.Custo_operacional.ToListAsync()) :
                          Problem("Entity set 'Contexto.Custo_operacional'  is null.");
        }

        // GET: CustoOperacional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Custo_operacional == null)
            {
                return NotFound();
            }

            var custo_operacional = await _context.Custo_operacional
                .FirstOrDefaultAsync(m => m.id_custo_operacional == id);
            if (custo_operacional == null)
            {
                return NotFound();
            }

            return View(custo_operacional);
        }

        // GET: CustoOperacional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustoOperacional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_custo_operacional,qtd_coordenador,custo_coordenador,qtd_profissionais_gerais,custo_profissionais_gerais,qtd_transporte,custo_transporte,qtd_balcoes,custo_balcoes,qtd_taxa_deslocamento,custo_taxa_deslocamento,qtd_impostos_federais,custo_impostos_federais,qtd_seguro_reserva,custo_seguro_reserva,qtd_taxa_operalizacao,custo_taxa_operalizacao,custo_operacional")] Custo_operacional custo_operacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custo_operacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custo_operacional);
        }

        // GET: CustoOperacional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Custo_operacional == null)
            {
                return NotFound();
            }

            var custo_operacional = await _context.Custo_operacional.FindAsync(id);
            if (custo_operacional == null)
            {
                return NotFound();
            }
            return View(custo_operacional);
        }

        // POST: CustoOperacional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_custo_operacional,qtd_coordenador,custo_coordenador,qtd_profissionais_gerais,custo_profissionais_gerais,qtd_transporte,custo_transporte,qtd_balcoes,custo_balcoes,qtd_taxa_deslocamento,custo_taxa_deslocamento,qtd_impostos_federais,custo_impostos_federais,qtd_seguro_reserva,custo_seguro_reserva,qtd_taxa_operalizacao,custo_taxa_operalizacao,custo_operacional")] Custo_operacional custo_operacional)
        {
            if (id != custo_operacional.id_custo_operacional)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custo_operacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Custo_operacionalExists(custo_operacional.id_custo_operacional))
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
            return View(custo_operacional);
        }

        // GET: CustoOperacional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Custo_operacional == null)
            {
                return NotFound();
            }

            var custo_operacional = await _context.Custo_operacional
                .FirstOrDefaultAsync(m => m.id_custo_operacional == id);
            if (custo_operacional == null)
            {
                return NotFound();
            }

            return View(custo_operacional);
        }

        // POST: CustoOperacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Custo_operacional == null)
            {
                return Problem("Entity set 'Contexto.Custo_operacional'  is null.");
            }
            var custo_operacional = await _context.Custo_operacional.FindAsync(id);
            if (custo_operacional != null)
            {
                _context.Custo_operacional.Remove(custo_operacional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Custo_operacionalExists(int id)
        {
          return (_context.Custo_operacional?.Any(e => e.id_custo_operacional == id)).GetValueOrDefault();
        }
    }
}
