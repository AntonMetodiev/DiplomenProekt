using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Entities
{
    public class Status
    {
        public Status()
        {
            this.Requests = new HashSet<Request>();
        }
        [Key]
       
        public int Id { get; set; }
        
        public string StatusName { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
