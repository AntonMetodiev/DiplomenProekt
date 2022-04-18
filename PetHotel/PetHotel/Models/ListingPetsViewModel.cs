using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Models
{
    public class ListingPetsViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int TypePetId { get; set; }

        public string TypePetName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
