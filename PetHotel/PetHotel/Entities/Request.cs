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
        public string Start { get; set; }

        [Required]
        public string End { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string StatusId { get; set; }
        
        public virtual Status Status { get; set; }
    }
}
