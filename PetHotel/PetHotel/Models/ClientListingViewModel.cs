using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Models
{
    public class ClientListingViewModel : IdentityUser
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [MinLength(10)]
        public int PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }
    }
}
