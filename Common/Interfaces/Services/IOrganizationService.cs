using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface IOrganizationService
    {
        OrganizationDTO GetOrganizationProfileDetails(Guid id);
        List<OfferDTO> GetAllOffersForOrganization(Guid id);

        List<OfferQuickInfoDTO> GetAllOffersForOrganizationOrderedByDate(Guid id);
        List<UserDTO> GetTopCandidates();

        List<OfferQuickInfoDTO> GetAllOffers();
        
    }
}
