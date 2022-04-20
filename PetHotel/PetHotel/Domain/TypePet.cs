using PetHotel.App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Entities
{
    public class TypePet
    {
        public TypePet()
        {
            this.Pets = new HashSet<Pet>();
            this.Places = new HashSet<Place>();
        }
        [Key]
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Place> Places { get; set; }

        
    }
}
