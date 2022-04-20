using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Entities
{
    public class Place
    {
        public Place()
        {
            this.Accomodations = new HashSet<Accomodation>();
           
        }
        [Key]
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TypePetId { get; set; }

        public virtual TypePet TypePet { get; set; }

        public int Area { get; set; }

        public virtual ICollection<Accomodation> Accomodations { get; set; }
        


    }
}
