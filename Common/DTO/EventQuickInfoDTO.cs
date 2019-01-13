using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class EventQuickInfoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationDTO Location { get; set; }
        public UserDTO Owner { get; set; }
        public List<DonationDetailDTO> Donations { get; set; }
        public DateTime DateTimeUTC { get; set; }

        public EventQuickInfoDTO()
        {

        }

        public EventQuickInfoDTO(EventDTO eventdto)
        {
            Id = eventdto.Id;
            Name = eventdto.Name;
            Location = eventdto.Location;
            Owner = eventdto.Owner;
            DateTimeUTC = eventdto.DateTimeUtc;
            Donations = eventdto.Donations.Select(x => new DonationDetailDTO(x.User, x.Amount)).ToList();
        }
    }
}
