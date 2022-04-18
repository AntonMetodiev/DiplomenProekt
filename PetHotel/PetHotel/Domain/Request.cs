using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Entities
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string PetId { get; set; }

        public virtual Pet Pet { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

                
        public int StatusId { get; set; }
        
        public virtual Status Status { get; set; }

        public int? AccomodationId { get; set; }
        public virtual Accomodation Accomodation { get; set; }
    }
}
