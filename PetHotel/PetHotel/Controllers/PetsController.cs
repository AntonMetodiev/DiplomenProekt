using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHotel.App.Abstraction;
using PetHotel.App.Entities;
using PetHotel.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            List<ListingPetsViewModel> pets = _petService.GetPets()
              .Select(item => new ListingPetsViewModel()
              {
                  Id = item.Id,
                  Name=item.Name,
                  Age=item.Age,
                  TypePetId=item.TypePetId,
                  TypePetName=item.TypePet.Name,
                  Description=item.Description

              }).ToList();
            return View(pets);
        }

        public IActionResult My()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ListingPetsViewModel> pets = _petService.GetPets()
              .Where(x=>x.UserId==currentUserId)
              .Select(item => new ListingPetsViewModel()
              {
                  Id = item.Id,
                  Name = item.Name,
                  Age = item.Age,
                  TypePetId = item.TypePetId,
                  TypePetName = item.TypePet.Name,
                  Description = item.Description

              }).ToList();
            return View(pets);
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
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var created = _petService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Description,
                    bindingModel.TypePetId, currentUserId );
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }

    }
}
