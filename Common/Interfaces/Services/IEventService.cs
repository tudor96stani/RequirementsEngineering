using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface IEventService
    {
        List<EventQuickInfoDTO> GetAll();
        List<EventQuickInfoDTO> GetEventsWithLocation(string cityName);
        List<EventDTO> GetAllDtos();
        EventDTO GetDto(Guid eventId);
        void AddParticipant(string eventId, string userId);
        bool Create(Guid organizationId,string name, string country, string city, string street, int number, DateTime date,string description,int volGoal, int donGoal);
        void Delete(Guid id);
        void UpdateEvent(string name, DateTime dateTimeUtc, string description, string locationId, Guid eventId);
    }
}
