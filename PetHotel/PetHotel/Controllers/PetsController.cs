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
    public class PetsController : Controller
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
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
            var pet = new CreatePetViewModel();
            pet.TypesPet = _petService.GetTypesPet()
                .Select(c => new ChoisePetTypeViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return View(pet);
        }


        // POST: PetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePetViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _petService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Description,
                    bindingModel.TypePetId);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }

      /*  // GET: PetController/Edit/5
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
        public ActionResult Edit(string id, CreatePetViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _petService.UpdatePet(id, bindingModel.Name, bindingModel.Age, bindingModel.Description, bindingModel.TypePet, bindingModel.TypePetId);
                if (updated)
                {
                    return this.RedirectToAction("All");
                }
            }
            return View(bindingModel);
        }

        // GET: PetController/Delete/5
        public ActionResult Delete(string id)
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
                Description = item.Description,
                TypePet = item.TypePet,
                TypePetId = item.TypePetId
            };
            return View(pet);
        }

        // POST: PetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            var deleted = _petService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("All", "Pets");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {
            return this.View();
        }
      */
    }
}
