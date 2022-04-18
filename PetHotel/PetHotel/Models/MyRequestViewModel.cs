using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Models
{
    public class MyRequestViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string PetId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }

        public int? AccomodationId { get; set; }

        public int TotalPrice { get; set; }
    }
}
