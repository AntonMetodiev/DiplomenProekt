using PetHotel.App.Abstraction;
using PetHotel.App.Entities;
using PetHotel.App.Models;
using PetHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Services
{
    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _context;

        public PetService(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public bool Create(string name, int age, string description,
                    string typePetId)
        {
            Pet item = new Pet
            {
                Name = name,
                Age = age,
                TypePetId = typePetId,
                Description = description
            };

            _context.Pets.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Pet GetPetById(string petId)
        {
            return _context.Pets.Find(petId);
        }

        public List<Pet> GetPets()
        {
            List<Pet> pets = _context.Pets.ToList();
            return pets;
        }

        public List<TypePet> GetTypesPet()
        {
            List<TypePet> typesPet = _context.TypePet.ToList();
            return typesPet;
        }

        /*  public List<Pet> GetPets(string searchStringType, string searchStringName)
          {
              List<Pet> pets = _context.Pets.ToList();
              if (!String.IsNullOrEmpty(searchStringType) && !String.IsNullOrEmpty(searchStringName))
              {
                  pets = pets.Where(d => d.TypePet.Contains(searchStringType) && d.Name.Contains(searchStringName)).ToList();
              }
              else if (!String.IsNullOrEmpty(searchStringType))
              {
                  pets = pets.Where(d => d.TypePet.Contains(searchStringType)).ToList();
              }
              else if (!String.IsNullOrEmpty(searchStringName))
              {
                  pets = pets.Where(d => d.Name.Contains(searchStringName)).ToList();
              }
              return pets;
          }*/

        public bool RemoveById(string petId)
        {
            var pet = GetPetById(petId);
            if (pet == default(Pet))
            {
                return false;
            }
            _context.Remove(pet);
            return _context.SaveChanges() != 0;
        }

        public bool UpdatePet(CreatePetViewModel pet)
        {
            var item = GetPetById(pet.Id);
            if (item == default(Pet))
            {
                return false;
            }
            pet.Name = pet.Name;
            pet.Age = pet.Age;
            pet.TypePetId = pet.TypePetId;
            pet.Description = pet.Description;
            _context.Update(pet);
            return _context.SaveChanges() != 0;
        }
        
    }
}
