using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface ICandidateService
    {
        CandidateDTO GetCandidateProfileDetails(Guid id);
		List<UserDTO> GetTopOrganizations();
		List<OfferDTO> GetAllOffersForCandidate(Guid id);
		List<OfferQuickInfoDTO> GetAllOffersForCandidateOrderedByDate(Guid id);
        List<OfferQuickInfoDTO> GetAllOffers();
    }
}
