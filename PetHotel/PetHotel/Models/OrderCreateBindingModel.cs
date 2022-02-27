using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Models
{
    public class OrderCreateBindingModel
    {
        [Required]

        public string RoomId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Tickets")]

        public int TicketsCount { get; set; }
    }
}
