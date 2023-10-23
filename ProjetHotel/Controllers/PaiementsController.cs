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
    public class PaiementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaiementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paiements
        public async Task<IActionResult> Index()
        {
              return _context.Paiements != null ? 
                          View(await _context.Paiements.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Paiements'  is null.");
        }

        // GET: Paiements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paiements == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement);
        }

        // GET: Paiements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paiements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prix,DatePaiment,Méthode,Satut,RéservationId")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paiement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paiement);
        }

        // GET: Paiements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paiements == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiements.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }
            return View(paiement);
        }

        // POST: Paiements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prix,DatePaiment,Méthode,Satut,RéservationId")] Paiement paiement)
        {
            if (id != paiement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paiement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaiementExists(paiement.Id))
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
            return View(paiement);
        }

        // GET: Paiements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paiements == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement);
        }

        // POST: Paiements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paiements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Paiements'  is null.");
            }
            var paiement = await _context.Paiements.FindAsync(id);
            if (paiement != null)
            {
                _context.Paiements.Remove(paiement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiementExists(int id)
        {
          return (_context.Paiements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
