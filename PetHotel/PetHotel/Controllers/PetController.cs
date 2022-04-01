using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHotel.App.Abstraction;
using PetHotel.App.Entities;
using PetHotel.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            this._petService = petService;
        }
        // GET: PetController
        public IActionResult Index()
        {
            return View();
        }

        // GET: PetController/Details/5
        public IActionResult Details(string id)
        {
            return View();
        }

        // GET: PetController/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: PetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePetViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _petService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Description,
                    bindingModel.TypePet);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }

        // GET: PetController/Edit/5
        public ActionResult Edit(string id)
        {
            Pet item = _petService.GetPetById(id);
            if (item == null)
            {
                return NotFound();
            }
            CreatePetViewModel pet = new CreatePetViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                TypePet = item.TypePet,
                TypePetId = item.TypePetId,
                Description = item.Description
            };
            return View(pet);
        }

        // POST: PetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetController/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: PetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
