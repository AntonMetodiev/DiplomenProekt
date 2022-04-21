using PetHotel.App.Abstraction;
using PetHotel.App.Entities;
using PetHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Services
{
    public class RequestService : IRequestService
    {
        private readonly ApplicationDbContext _context;

        public RequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ApproveRequest(string requestId, string petId, DateTime startDate, DateTime endDateint, int statusId, int accomodationId)
        {
            throw new NotImplementedException();
        }

        public bool CreateRequest(string petId, DateTime startDate, DateTime endDate)
        {
           // var client = _context.Users.FirstOrDefault(x => x.Id==userId);
            var request = new Request
            {
                PetId=petId,
                StartDate=startDate,
                EndDate=endDate,
                StatusId=2,
                              

            };

            _context.Requests.Add(request);
          
            return _context.SaveChanges() != 0;
        }
    }
}
