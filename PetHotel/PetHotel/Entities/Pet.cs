using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Entities
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string TypePetId { get; set; }

        public virtual TypePet TypePet { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
