using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Entities
{
    public class Accomodation
    {
        public Accomodation()
        {
            this.Requests = new HashSet<Request>();
        }
        [Key]
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public decimal PricePerNight { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

    }
}
