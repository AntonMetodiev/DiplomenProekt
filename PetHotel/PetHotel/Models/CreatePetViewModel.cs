using PetHotel.App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Models
{
    public class CreatePetViewModel
    {
        public CreatePetViewModel()
        {
            TypesPet = new List<ChoisePetTypeViewModel>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Display(Name="Type of pet")]
        public string TypePetId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual List<ChoisePetTypeViewModel> TypesPet { get; set; }
    }
}
