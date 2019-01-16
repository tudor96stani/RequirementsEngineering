using Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Core.DAL;
using Core.Utils;
using System.Data.Entity;

namespace Core.Services
{
    public class OrganizationService : IOrganizationService
    {
        public OrganizationDTO GetOrganizationProfileDetails(Guid id)

        {
            using(var db = new ApplicationDbContext())
            {
                //Get the user object that corresponds to the organization
                var organizationModelObj = db.AspNetUsers.FirstOrDefault(x => x.Id == id.ToString()).ToDTO();
                //Convert the UserDTO to an OrganizationDTO
                var dto = new OrganizationDTO(organizationModelObj);
                //Get the ratings associated to this particular user
                var ratings = db.Ratings.Where(x => x.UserId == id.ToString()).ToList();
                //Compute the average rating
                var averageRating = ratings.Select(x => x.Rating1).Average();
                dto.OrganizationRating = averageRating == 0 ? (double)averageRating : 0;
                return dto;
            }
        }

        public List<OfferDTO> GetAllOffersForOrganization(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var offers = db.Offers.Where(x => x.OwnerId == id.ToString()).ToList().Select(x => x.ToDTO()).ToList();
                return offers;
            }
        }

        public List<OfferQuickInfoDTO> GetAllOffersForOrganizationOrderedByDate(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var offers = db.Offers.Where(x => x.OwnerId == id.ToString()).ToList().Select(x => x.ToDTO()).OrderByDescending(x => x.DateTimeUtc).ToList().Select(x => new OfferQuickInfoDTO(x)).ToList();
                return offers;
            }
        }

        public List<UserDTO> GetTopCandidates()
        {
            using (var db = new ApplicationDbContext())
            {
                AspNetRole candidateRole = db.AspNetRoles.FirstOrDefault(x => x.Name == "Candidate");
                var topCandidates = db.AspNetUsers.Include(x => x.Ratings).Where(x=>x.AspNetRoles.Any(y=>y.Name=="Candidate")).OrderByDescending(x => x.Ratings.Select(y => y.Rating1).Average()).Take(10).ToList();
                return topCandidates.Select(x => x.ToDTO()).ToList();
            }
        }

        public List<OfferQuickInfoDTO> GetAllOffers()
        {
            using(var db = new ApplicationDbContext())
            {
                var offers = db.Offers.Include(x => x.Owner).Include(x => x.Location).Include(x => x.Donations).OrderByDescending(x => x.DateTimeUTC).ToList().Select(x=>x.ToDTO()).Select(x => new OfferQuickInfoDTO(x)).ToList();
                return offers;
            }
        }
    }
}
