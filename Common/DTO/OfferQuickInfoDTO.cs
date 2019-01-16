using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class OfferQuickInfoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationDTO Location { get; set; }
        public UserDTO Owner { get; set; }
        public List<DonationDetailDTO> Donations { get; set; }
        public DateTime DateTimeUTC { get; set; }

        public OfferQuickInfoDTO()
        {

        }

        public OfferQuickInfoDTO(OfferDTO offerdto)
        {
            Id = offerdto.Id;
            Name = offerdto.Name;
            Location = offerdto.Location;
            Owner = offerdto.Owner;
            DateTimeUTC = offerdto.DateTimeUtc;
            Donations = offerdto.Donations.Select(x => new DonationDetailDTO(x.User, x.Amount)).ToList();
        }
    }
}
