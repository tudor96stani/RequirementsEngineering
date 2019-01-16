using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface IOfferService
    {
        List<OfferQuickInfoDTO> GetAll();
        List<OfferQuickInfoDTO> GetOffersWithLocation(string cityName);
        List<OfferDTO> GetAllDtos();
        OfferDTO GetDto(Guid offerId);
        void AddParticipant(string offerId, string userId);
        bool Create(Guid organizationId,string name, string country, string city, string street, int number, DateTime date,string description,int volGoal);
        void Delete(Guid id);
        void UpdateOffer(string name, DateTime dateTimeUtc, string description, string locationId, Guid offerId);
    }
}
