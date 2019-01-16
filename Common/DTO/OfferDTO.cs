using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class OfferDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserDTO Owner { get; set; }
        public List<UserDTO> Participants { get; set; }
        public LocationDTO Location { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public string Description { get; set; }
    }
}
