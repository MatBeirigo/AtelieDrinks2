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
              return _context.CustoOperacional != null ? 
                          View(await _context.CustoOperacional.ToListAsync()) :
                          Problem("Entity set 'Contexto.CustoOperacional'  is null.");
        }

        // GET: CustoOperacional/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.CustoOperacional == null)
        //    {
        //        return NotFound();
        //    }

        //    var CustoOperacional = await _context.CustoOperacional
        //        .FirstOrDefaultAsync(m => m.IdCustoOperacional == id);
        //    if (CustoOperacional == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(CustoOperacional);
    }

        // GET: CustoOperacional/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: CustoOperacional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("IdCustoOperacional,QtdCoordenador,ValorCoordenador,CustoCoordenador,QtdProfissionaisGerais,ValorProfissionaisGerais,CustoProfissionaisGerais,QtdTransporte,ValorTransporte,CustoTransporte,QtdBalcoes,ValorBalcoes,CustoBalcoes,CustoTaxaDeslocamentoId,QtdImpostosFederais,ValorImpostosFederais,CustoImpostosFederais,QtdSeguroReserva,ValorSeguroReserva,CustoSeguroReserva,QtdTaxaOperacional,ValorTaxaOperacional,CustoTaxaOperacional,CustoOperacional")] CustoOperacional CustoOperacional)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(CustoOperacional);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(CustoOperacional);
        //}

        // GET: CustoOperacional/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.CustoOperacional == null)
        //    {
        //        return NotFound();
        //    }

        //    var CustoOperacional = await _context.CustoOperacional.FindAsync(id);
        //    if (CustoOperacional == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(CustoOperacional);
        //}

        //// POST: CustoOperacional/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdCustoOperacional,QtdCoordenador,ValorCoordenador,CustoCoordenador,QtdProfissionaisGerais,ValorProfissionaisGerais,CustoProfissionaisGerais,QtdTransporte,ValorTransporte,CustoTransporte,QtdBalcoes,ValorBalcoes,CustoBalcoes,CustoTaxaDeslocamentoId,QtdImpostosFederais,ValorImpostosFederais,CustoImpostosFederais,QtdSeguroReserva,ValorSeguroReserva,CustoSeguroReserva,QtdTaxaOperacional,ValorTaxaOperacional,CustoTaxaOperacional,CustoOperacional")] CustoOperacional CustoOperacional)
        //{
        //    if (id != CustoOperacional.IdCustoOperacional)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(CustoOperacional);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustoOperacionalExists(CustoOperacional.IdCustoOperacional))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(CustoOperacional);
        //}

        //// GET: CustoOperacional/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.CustoOperacional == null)
        //    {
        //        return NotFound();
        //    }

        //    var CustoOperacional = await _context.CustoOperacional
        //        .FirstOrDefaultAsync(m => m.IdCustoOperacional == id);
        //    if (CustoOperacional == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(CustoOperacional);
        //}

        //// POST: CustoOperacional/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.CustoOperacional == null)
        //    {
        //        return Problem("Entity set 'Contexto.CustoOperacional'  is null.");
        //    }
        //    var CustoOperacional = await _context.CustoOperacional.FindAsync(id);
        //    if (CustoOperacional != null)
        //    {
        //        _context.CustoOperacional.Remove(CustoOperacional);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CustoOperacionalExists(int id)
        //{
        //  return (_context.CustoOperacional?.Any(e => e.IdCustoOperacional == id)).GetValueOrDefault();
        //}
}
