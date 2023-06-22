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
    public class DrinksController : Controller
    {
        private readonly Contexto _context;

        public DrinksController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Drinks != null ? 
                          View(await _context.Drinks.ToListAsync()) :
                          Problem("Entity set 'Contexto.Drinks'  is null.");
        }

        /// <summary>
        /// Método usado para listar todos os drinks cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet, ActionName("ListarDrinks")]
        public async Task<List<Drinks>> ListarDrinks()
        {
            try
            {
                var drinks = await _context.Drinks.ToListAsync();
                return drinks;
            }
            catch (Exception ex)
            {
                Problem("Ocorreu um erro ao buscar os dados da tabela de Drinks: " + ex.Message);
                return null;
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var drinks = await _context.Drinks
                .FirstOrDefaultAsync(m => m.IdDrink == id);
            if (drinks == null)
            {
                return NotFound();
            }

            return View(drinks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdDrink,NomeDrink,CustoDoDrink,Quantidade,IngredientesDoDrink")] Drinks drinks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drinks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drinks);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var drinks = await _context.Drinks.FindAsync(id);
            if (drinks == null)
            {
                return NotFound();
            }
            return View(drinks);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdDrink,NomeDrink,CustoDoDrink,Quantidade,IngredientesDoDrink")] Drinks drinks)
        {
            if (id != drinks.IdDrink)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drinks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinksExists(drinks.IdDrink))
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
            return View(drinks);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var drinks = await _context.Drinks
                .FirstOrDefaultAsync(m => m.IdDrink == id);
            if (drinks == null)
            {
                return NotFound();
            }

            return View(drinks);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drinks == null)
            {
                return Problem("Entity set 'Contexto.Drinks'  is null.");
            }
            var drinks = await _context.Drinks.FindAsync(id);
            if (drinks != null)
            {
                _context.Drinks.Remove(drinks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinksExists(int id)
        {
          return (_context.Drinks?.Any(e => e.IdDrink == id)).GetValueOrDefault();
        }
    }
}
