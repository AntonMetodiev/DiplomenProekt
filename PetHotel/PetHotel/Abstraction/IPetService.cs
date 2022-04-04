using PetHotel.App.Entities;
using PetHotel.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Abstraction
{
    public interface IPetService
    {
        public bool Create(string name, int age, string description,
                    string typePetId);
        public bool UpdatePet(CreatePetViewModel pet);
        public List<Pet> GetPets();
        public Pet GetPetById(string petId);
        public bool RemoveById(string petId);
        // public List<Pet> GetPets(string searchStringType, string searchStringName);
        public List<TypePet> GetTypesPet();
    }
}
