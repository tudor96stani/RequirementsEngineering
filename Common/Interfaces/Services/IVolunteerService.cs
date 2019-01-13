using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface IVolunteerService
    {
        VolunteerDTO GetVolunteerProfileDetails(Guid id);
		List<UserDTO> GetTopOrganizations();
		List<EventDTO> GetAllEventsForVolunteer(Guid id);
		List<EventQuickInfoDTO> GetAllEventsForVolunteerOrderedByDate(Guid id);
        List<EventQuickInfoDTO> GetAllEvents();
    }
}
