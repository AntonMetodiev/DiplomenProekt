using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetHotel.App.Entities;
using PetHotel.Data;

namespace PetHotel.App.Controllers
{
    public class AccomodationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccomodationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Accomodations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Accomodations.Include(a => a.Place);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Accomodations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations
                .Include(a => a.Place)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accomodation == null)
            {
                return NotFound();
            }

            return View(accomodation);
        }

        // GET: Accomodations/Create
        public IActionResult Create()
        {
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id");
            return View();
        }

        // POST: Accomodations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PlaceId,PricePerNight")] Accomodation accomodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accomodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id", accomodation.PlaceId);
            return View(accomodation);
        }

        // GET: Accomodations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations.FindAsync(id);
            if (accomodation == null)
            {
                return NotFound();
            }
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id", accomodation.PlaceId);
            return View(accomodation);
        }

        // POST: Accomodations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,PlaceId,PricePerNight")] Accomodation accomodation)
        {
            if (id != accomodation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accomodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccomodationExists(accomodation.Id))
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
            ViewData["PlaceId"] = new SelectList(_context.Places, "Id", "Id", accomodation.PlaceId);
            return View(accomodation);
        }

        // GET: Accomodations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations
                .Include(a => a.Place)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accomodation == null)
            {
                return NotFound();
            }

            return View(accomodation);
        }

        // POST: Accomodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accomodation = await _context.Accomodations.FindAsync(id);
            _context.Accomodations.Remove(accomodation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccomodationExists(string id)
        {
            return _context.Accomodations.Any(e => e.Id == id);
        }
    }
}
