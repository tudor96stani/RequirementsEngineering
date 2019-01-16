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

    public class OfferService : IOfferService
    {
        public List<OfferQuickInfoDTO> GetAll()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                
                var offers = dbContext.Offers.Include(x => x.Owner).Include(x => x.Donations).Include(x => x.Location).ToList().Select(x => x.ToDTO());
                var result = new List<OfferQuickInfoDTO>();
                foreach(var offerObj in offers)
                {
                    result.Add(new OfferQuickInfoDTO(offerObj));
                }

                return result;
            }
        }

        public List<OfferDTO> GetAllDtos()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var offers = dbContext.Offers.Include(x => x.Owner).Include(x => x.Donations).Include(x => x.Location).ToList().Select(x => x.ToDTO()).ToList();
                return offers;


            }
        }

        public OfferDTO GetDto(Guid offerId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var offerDto = dbContext.Offers.Include(x => x.Owner).Include(x => x.Donations).Include(x => x.Location).ToList().Select(x => x.ToDTO()).FirstOrDefault(x=>x.Id==offerId);
                return offerDto;


            }
        }

        public void AddParticipant(string offerId, string userId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var offert = dbContext.Offers.Include(x => x.Participants).FirstOrDefault(x => x.Id == offerId.ToString());
                var user = dbContext.AspNetUsers.FirstOrDefault(u => u.Id == userId);
                offert?.Participants.Add(user);
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
                var ev = new Offer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    LocationId= location.Id.ToString(),
                    Location=location,
                    DateTimeUTC= date.ToUniversalTime(),
                    OwnerId=owner.Id,
                    Owner = owner,
                    Description=description,
                    CandidatesGoal=volGoal,
                    DonationsGoal=donGoal
                };
                var result = dbContext.Offers.Add(ev);
                
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
                var offerObj = dbContext.Offers.Include(x=>x.Participants).Include(x=>x.Donations).Include(x=>x.Location).Include(x=>x.Owner).FirstOrDefault(x => x.Id == id.ToString());
                if (offerObj == null)
                    throw new Exception("Object could not be found!");
                
                dbContext.Offers.Remove(offerObj);
                dbContext.SaveChanges();
            }
        }
        public void UpdateOffer(string name, DateTime dateTimeUtc, string description, string locationId, Guid offerId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Offer offert = dbContext.Offers.Find(offerId.ToString());
                if (offert != null)
                {
                    offert.Name = name;
                    offert.DateTimeUTC = dateTimeUtc;
                    offert.LocationId = locationId;
                    offert.Description = description;
                    dbContext.SaveChanges();

                }
            }
        }
        public List<OfferQuickInfoDTO> GetOffersWithLocation(string cityName)
        {
            using(var dbCtx = new ApplicationDbContext())
            {
                var locationIdsFromRequestedCity = dbCtx.Locations.Where(x => x.City == cityName).Select(x => x.Id).ToList();
                var offers = dbCtx.Offers.Include(x => x.Location).Where(x => locationIdsFromRequestedCity.Contains(x.LocationId)).OrderByDescending(x=>x.DateTimeUTC).ToList();
                return offers.Select(x => new OfferQuickInfoDTO(x.ToDTO())).ToList();
            }
        }
    }
}
