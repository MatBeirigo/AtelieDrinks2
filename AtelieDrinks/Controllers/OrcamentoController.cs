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
    public class OrcamentoController : Controller
    {
        private readonly Contexto _context;

        public OrcamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index()
        {
            return _context.Orcamento != null ?
                        View(await _context.Orcamento.ToListAsync()) :
                        Problem("Entity set 'Contexto.Orcamento'  is null.");
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orcamento == null)
            {
                return NotFound();
            }

            var Orcamento = await _context.Orcamento
                .FirstOrDefaultAsync(m => m.id_orcamento == id);
            if (Orcamento == null)
            {
                return NotFound();
            }

            return View(Orcamento);
        }

        //private readonly Data.Contexto _context;
        [Route("Orcamento/{numberPage:int?}")]
        public ActionResult Index(int? numberPage)
        {
            switch (numberPage)
            {
                case 1:
                    return View("~/Views/Orcamento/Index1.cshtml");
                case 2:
                    return View("~/Views/Orcamento/Index2.cshtml");
                case 3:
                    return View("~/Views/Orcamento/Index3.cshtml");
                case 4:
                    return View("~/Views/Orcamento/Index4.cshtml");
                case 5:
                    return View("~/Views/Orcamento/Index5.cshtml");
                // Adicione outros casos conforme necessário
                default:
                    return NotFound(); // Retorna um erro 404 se o número da página não for válido
            }
        }

         // GET: Orcamento/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createnumero_pessoas([Bind("numero_pessoas")] Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orcamento);
        }
        public async Task<IActionResult> Create_custosOp([Bind("custo_operacional")] Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orcamento);
        }


        // POST: Orcamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        /*
        public OrcamentoController(Data.Contexto context)
        {
            _context = context;
        }

        // GET: Orcamento
        public async Task<IActionResult> Index()
        {
              return _context.Orcamento != null ? 
                          View(await _context.Orcamento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Orcamento'  is null.");
        }

        // GET: Orcamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orcamento == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamento
                .FirstOrDefaultAsync(m => m.id_orcamento == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // GET: Orcamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orcamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_orcamento,numero_pessoas,custo_operacional,custo_total_insumos,custo_total,base_orcamento,comissao_comercial,comissao_gerencia,valor_primario,custo_por_pessoa,valor_arredondado_pra_cima,margem_negociacao,valor_orcamento,previsao_lucro,qtde_convidados,qtde_drinks")] Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orcamento);
        }

        // GET: Orcamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orcamento == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamento.FindAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            return View(orcamento);
        }

        // POST: Orcamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_orcamento,numero_pessoas,custo_operacional,custo_total_insumos,custo_total,base_orcamento,comissao_comercial,comissao_gerencia,valor_primario,custo_por_pessoa,valor_arredondado_pra_cima,margem_negociacao,valor_orcamento,previsao_lucro,qtde_convidados,qtde_drinks")] Orcamento orcamento)
        {
            if (id != orcamento.id_orcamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoExists(orcamento.id_orcamento))
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
            return View(orcamento);
        }

        // GET: Orcamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orcamento == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamento
                .FirstOrDefaultAsync(m => m.id_orcamento == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // POST: Orcamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orcamento == null)
            {
                return Problem("Entity set 'Contexto.Orcamento'  is null.");
            }
            var orcamento = await _context.Orcamento.FindAsync(id);
            if (orcamento != null)
            {
                _context.Orcamento.Remove(orcamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoExists(int id)
        {
          return (_context.Orcamento?.Any(e => e.id_orcamento == id)).GetValueOrDefault();
        }*/
    }
}



