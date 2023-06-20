using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var historicos = await _context.Historico.ToListAsync();
            return View(historicos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .FirstOrDefaultAsync(m => m.IdHistorico == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHistorico,NumeroPessoas,CustoOperacional,CustoTotalInsumos,CustoTotal,BaseOrcamento,ComissaoComercial,ComissaoGerencia,ValorPrimario,CustoPorPessoa,ValorArredondadoPraCima,MargemNegociacao,ValorOrcamento,PrevisaoLucro")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historico);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHistorico,NumeroPessoas,CustoOperacional,CustoTotalInsumos,CustoTotal,BaseOrcamento,ComissaoComercial,ComissaoGerencia,ValorPrimario,CustoPorPessoa,ValorArredondadoPraCima,MargemNegociacao,ValorOrcamento,PrevisaoLucro")] Historico historico)
        {
            if (id != historico.IdHistorico)
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
                    if (!HistoricoExists(historico.IdHistorico))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .FirstOrDefaultAsync(m => m.IdHistorico == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historico = await _context.Historico.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }

            _context.Historico.Remove(historico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.IdHistorico == id);
        }
    }
}
