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
        public bool Create(CreatePetViewModel pet);
        public bool UpdatePet(CreatePetViewModel pet);
        public List<TypePet> GetTypePets();

        Pet GetPetById(int petId);
        public bool RemoveById(int petId);

    }
}
