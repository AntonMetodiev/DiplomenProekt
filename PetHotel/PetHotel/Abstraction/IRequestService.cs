using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Abstraction
{
    public interface IRequestService
    {
        bool CreateRequest(string petId, DateTime startDate, DateTime endDate);
        bool ApproveRequest(string requestId, string petId, DateTime startDate, DateTime endDateint, int statusId, int accomodationId);
    }
}
