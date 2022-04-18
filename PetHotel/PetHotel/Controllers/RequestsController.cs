using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetHotel.App.Abstraction;
using PetHotel.App.Entities;
using PetHotel.App.Models;
using PetHotel.Data;

namespace PetHotel.App.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPetService _petService;
        private readonly IRequestService _requestService;

        public RequestsController(ApplicationDbContext context, 
            IPetService petService, IRequestService requestService)
        {
            _context = context;
            _petService = petService;
            _requestService = requestService;
        }




        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requests.Include(r => r.Accomodation).Include(r => r.Pet).Include(r => r.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Accomodation)
                .Include(r => r.Pet)
                .Include(r => r.Status)
               
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create(string id)
        {
            /* ViewData["AccomodationId"] = new SelectList(_context.Accomodations, "Id", "Name");
             ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Name");
             ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
             ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
             return View();*/

            if (id==null)
            {
                return NotFound();
            }

            Pet item = _petService.GetPetById(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateRequestViewModel request = new CreateRequestViewModel();
            request.PetId = item.Id;
            request.StartDate = DateTime.Now;
            request.EndDate = DateTime.Now;
     
            return View(request);
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string id, CreateRequestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return NotFound();
            }
            //  string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = _petService.GetPetById(id).UserId;
            //по id на домашния любимец намираме userId на потребителя, който го е регистрирал
            var created = _requestService.CreateRequest(id, model.StartDate, model.EndDate);
            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["AccomodationId"] = new SelectList(_context.Accomodations, "Id", "Name", request.AccomodationId);
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Id", request.PetId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", request.StatusId);
           
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PetId,StartDate,EndDate,UserId,StatusId,AccomodationId")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
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
            ViewData["AccomodationId"] = new SelectList(_context.Accomodations, "Id", "Name", request.AccomodationId);
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Id", request.PetId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", request.StatusId);
            
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Accomodation)
                .Include(r => r.Pet)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(string id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
