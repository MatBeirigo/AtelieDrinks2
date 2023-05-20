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
    public class HistoricoController : Controller
    {
        private readonly Contexto _context;

        public HistoricoController(Contexto context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index()
        {
              return _context.Historico != null ? 
                          View(await _context.Historico.ToListAsync()) :
                          Problem("Entity set 'Contexto.Historico'  is null.");
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Historico == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .FirstOrDefaultAsync(m => m.id_historico == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        // GET: Historico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_historico,numero_pessoas,custo_operacional,custo_total_insumos,custo_total,base_orcamento,comissao_comercial,comissao_gerencia,valor_primario,custo_por_pessoa,valor_arredondado_pra_cima,margem_negociacao,valor_orcamento,previsao_lucro,qtde_convidados,qtde_drinks")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historico);
        }

        // GET: Historico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Historico == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }
            return View(historico);
        }

        // POST: Historico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_historico,numero_pessoas,custo_operacional,custo_total_insumos,custo_total,base_orcamento,comissao_comercial,comissao_gerencia,valor_primario,custo_por_pessoa,valor_arredondado_pra_cima,margem_negociacao,valor_orcamento,previsao_lucro,qtde_convidados,qtde_drinks")] Historico historico)
        {
            if (id != historico.id_historico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoExists(historico.id_historico))
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
            return View(historico);
        }

        // GET: Historico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Historico == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .FirstOrDefaultAsync(m => m.id_historico == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        // POST: Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Historico == null)
            {
                return Problem("Entity set 'Contexto.Historico'  is null.");
            }
            var historico = await _context.Historico.FindAsync(id);
            if (historico != null)
            {
                _context.Historico.Remove(historico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoExists(int id)
        {
          return (_context.Historico?.Any(e => e.id_historico == id)).GetValueOrDefault();
        }
    }
}
