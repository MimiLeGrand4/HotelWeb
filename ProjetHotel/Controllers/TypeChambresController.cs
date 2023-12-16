using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetHotel.Models;

namespace ProjetHotel.Controllers
{
    public class TypeChambresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeChambresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeChambres
        public async Task<IActionResult> Index()
        {
              return _context.TypeChambres != null ? 
                          View(await _context.TypeChambres.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TypeChambres'  is null.");
        }

        // GET: TypeChambres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeChambres == null)
            {
                return NotFound();
            }

            var typeChambre = await _context.TypeChambres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeChambre == null)
            {
                return NotFound();
            }

            return View(typeChambre);
        }

        // GET: TypeChambres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeChambres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] TypeChambre typeChambre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeChambre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeChambre);
        }

        // GET: TypeChambres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeChambres == null)
            {
                return NotFound();
            }

            var typeChambre = await _context.TypeChambres.FindAsync(id);
            if (typeChambre == null)
            {
                return NotFound();
            }
            return View(typeChambre);
        }

        // POST: TypeChambres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] TypeChambre typeChambre)
        {
            if (id != typeChambre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeChambre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeChambreExists(typeChambre.Id))
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
            return View(typeChambre);
        }

        // GET: TypeChambres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeChambres == null)
            {
                return NotFound();
            }

            var typeChambre = await _context.TypeChambres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeChambre == null)
            {
                return NotFound();
            }

            return View(typeChambre);
        }

        // POST: TypeChambres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeChambres == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TypeChambres'  is null.");
            }
            var typeChambre = await _context.TypeChambres.FindAsync(id);
            if (typeChambre != null)
            {
                _context.TypeChambres.Remove(typeChambre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeChambreExists(int id)
        {
          return (_context.TypeChambres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
