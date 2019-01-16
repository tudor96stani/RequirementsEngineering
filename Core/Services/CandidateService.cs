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
    public class CandidateService : ICandidateService
    {
        public CandidateDTO GetCandidateProfileDetails(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                //Get the user object that corresponds to the organization
                var candidateModelObj = db.AspNetUsers.FirstOrDefault(x => x.Id == id.ToString()).ToDTO();
                //Convert the UserDTO to a CandidateDTO
                var dto = new CandidateDTO(candidateModelObj);
                //Get the ratings associated to this particular user
                var ratings = db.Ratings.Where(x => x.UserId == id.ToString()).ToList();
                //Compute the average rating
                var averageRating = ratings.Select(x => x.Rating1).Average();
                dto.CandidateRating = averageRating == 0 ? (double)averageRating : 0;
                return dto;
            }
        }

        public List<UserDTO> GetTopOrganizations()
        {
            using (var db = new ApplicationDbContext())
            {
                AspNetRole organizationRole = db.AspNetRoles.FirstOrDefault(x => x.Name == "Organization");
                var topOrganizations = db.AspNetUsers.Include(x => x.Ratings).Where(x=>x.AspNetRoles.Any(y=>y.Name=="Organization")).OrderByDescending(x => x.Ratings.Select(y => y.Rating1).Average()).Take(10).ToList();
                return topOrganizations.Select(x => x.ToDTO()).ToList();
            }
        }

		public List<OfferDTO> GetAllOffersForCandidate(Guid id)
		{
			using (var db = new ApplicationDbContext())
			{
				var offers = db.Offers.Where(y => y.Participants.Any(x => x.Id == id.ToString()) == true).ToList().Select(x => x.ToDTO()).ToList();
				return offers;
			}
		}

		public List<OfferQuickInfoDTO> GetAllOffersForCandidateOrderedByDate(Guid id)
		{
			using (var db = new ApplicationDbContext())
			{
				//var offers = db.Offers.Where(x => x.OwnerId == id.ToString()).ToList().Select(x => x.ToDTO()).OrderBy(x => x.DateTimeUtc).ToList().Select(x => new OfferQuickInfoDTO(x)).ToList();
				var offers = db.Offers.Where(y => y.Participants.Any(x => x.Id == id.ToString()) == true).ToList()
					.Select(x => x.ToDTO()).OrderBy(x => x.DateTimeUtc).ToList().Select(x => new OfferQuickInfoDTO(x)).ToList();
                return offers;
			}
		}

        public List<OfferQuickInfoDTO> GetAllOffers()
        {
            using (var db = new ApplicationDbContext())
            {
                var offers = db.Offers.Include(x => x.Owner).Include(x => x.Location).Include(x => x.Donations).OrderByDescending(x => x.DateTimeUTC).ToList().Select(x => x.ToDTO()).Select(x => new OfferQuickInfoDTO(x)).ToList();
                return offers;
            }
        }
    }
}
