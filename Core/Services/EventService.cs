using Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Core.DAL;
using System.Data.Entity;
using Core.Utils;
using System.Data.Entity;
namespace Core.Services
{

    public class EventService : IEventService
    {
        public List<EventQuickInfoDTO> GetAll()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                
                var events = dbContext.Events.Include(x => x.Owner).Include(x => x.Donations).Include(x => x.Location).ToList().Select(x => x.ToDTO());
                var result = new List<EventQuickInfoDTO>();
                foreach(var eventObj in events)
                {
                    result.Add(new EventQuickInfoDTO(eventObj));
                }

                return result;
            }
        }

        public List<EventDTO> GetAllDtos()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var events = dbContext.Events.Include(x => x.Owner).Include(x => x.Donations).Include(x => x.Location).ToList().Select(x => x.ToDTO()).ToList();
                return events;


            }
        }

        public EventDTO GetDto(Guid eventId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var eventDto = dbContext.Events.Include(x => x.Owner).Include(x => x.Donations).Include(x => x.Location).ToList().Select(x => x.ToDTO()).FirstOrDefault(x=>x.Id==eventId);
                return eventDto;


            }
        }

        public void AddParticipant(string eventId, string userId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var eventt = dbContext.Events.Include(x => x.Participants).FirstOrDefault(x => x.Id == eventId.ToString());
                var user = dbContext.AspNetUsers.FirstOrDefault(u => u.Id == userId);
                eventt?.Participants.Add(user);
                dbContext.SaveChanges();
            }

        }
        public bool Create(Guid organizationId,string name, string country, string city, string street, int number, DateTime date,string description,int volGoal,int donGoal)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Location location = dbContext.Locations.FirstOrDefault(x => x.Country == country && x.City == city && x.Street == street && x.Number == number);
                if (location == null)
                {
                    location = dbContext.Locations.Add(new Location() { Id = Guid.NewGuid().ToString(), Country = country, City = city, Street = street, Number = number });
                }
                var owner = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == organizationId.ToString());
                var ev = new Event()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    LocationId= location.Id.ToString(),
                    Location=location,
                    DateTimeUTC= date.ToUniversalTime(),
                    OwnerId=owner.Id,
                    Owner = owner,
                    Description=description,
                    VolunteersGoal=volGoal,
                    DonationsGoal=donGoal
                };
                var result = dbContext.Events.Add(ev);
                
                dbContext.SaveChanges();
                if (result == null)
                    return false;
                return true;
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var eventObj = dbContext.Events.Include(x=>x.Participants).Include(x=>x.Donations).Include(x=>x.Location).Include(x=>x.Owner).FirstOrDefault(x => x.Id == id.ToString());
                if (eventObj == null)
                    throw new Exception("Object could not be found!");
                
                dbContext.Events.Remove(eventObj);
                dbContext.SaveChanges();
            }
        }
        public void UpdateEvent(string name, DateTime dateTimeUtc, string description, string locationId, Guid eventId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Event eventt = dbContext.Events.Find(eventId.ToString());
                if (eventt != null)
                {
                    eventt.Name = name;
                    eventt.DateTimeUTC = dateTimeUtc;
                    eventt.LocationId = locationId;
                    eventt.Description = description;
                    dbContext.SaveChanges();

                }
            }
        }
        public List<EventQuickInfoDTO> GetEventsWithLocation(string cityName)
        {
            using(var dbCtx = new ApplicationDbContext())
            {
                var locationIdsFromRequestedCity = dbCtx.Locations.Where(x => x.City == cityName).Select(x => x.Id).ToList();
                var events = dbCtx.Events.Include(x => x.Location).Where(x => locationIdsFromRequestedCity.Contains(x.LocationId)).OrderByDescending(x=>x.DateTimeUTC).ToList();
                return events.Select(x => new EventQuickInfoDTO(x.ToDTO())).ToList();
            }
        }
    }
}
