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
    public class ChambresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChambresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chambres
        public async Task<IActionResult> Index(string tri)
        {
            if (_context.Chambres != null)
            {
                var chambresTriees = tri switch
                {
                    "Prix" => await _context.Chambres.OrderBy(c => c.Prix).ToListAsync(),
                    "Description" => await _context.Chambres.OrderBy(c => c.Description).ToListAsync(),
                    "Disponible" => await _context.Chambres.OrderBy(c => c.Disponible).ToListAsync(),
                    "Type" => await _context.Chambres.OrderBy(c => c.TypeChambre).ToListAsync(),
                    // Ajoutez d'autres cas selon les options de tri
                    _ => await _context.Chambres.ToListAsync(), // Tri par défaut
                };

                return View(chambresTriees);
            }
            return Problem("Entity set 'ApplicationDbContext.Chambres' is null.");

            /*return _context.Chambres != null ? 
                        View(await _context.Chambres.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Chambres'  is null.");*/
        }

        // GET: Chambres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chambres == null)
            {
                return NotFound();
            }

            var chambre = await _context.Chambres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chambre == null)
            {
                return NotFound();
            }

            return View(chambre);
        }

        // GET: Chambres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chambres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,NuméroPorte,NombreLit,Prix,Disponible,UrlImage")] Chambre chambre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chambre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chambre);
        }

        // GET: Chambres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chambres == null)
            {
                return NotFound();
            }

            var chambre = await _context.Chambres.FindAsync(id);
            if (chambre == null)
            {
                return NotFound();
            }
            return View(chambre);
        }

        // POST: Chambres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,NuméroPorte,NombreLit,Prix,Disponible,UrlImage")] Chambre chambre)
        {
            if (id != chambre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chambre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChambreExists(chambre.Id))
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
            return View(chambre);
        }

        // GET: Chambres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chambres == null)
            {
                return NotFound();
            }

            var chambre = await _context.Chambres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chambre == null)
            {
                return NotFound();
            }

            return View(chambre);
        }

        // POST: Chambres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chambres == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Chambres'  is null.");
            }
            var chambre = await _context.Chambres.FindAsync(id);
            if (chambre != null)
            {
                _context.Chambres.Remove(chambre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChambreExists(int id)
        {
            return (_context.Chambres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
