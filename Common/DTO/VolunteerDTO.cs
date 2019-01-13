using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class VolunteerDTO
    {
        public Guid VolunteerId { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerEmail { get; set; }
        public double VolunteerRating { get; set; }

        public VolunteerDTO(UserDTO userDTO)
        {
            VolunteerId = userDTO.Id;
            VolunteerName = userDTO.FullName;
            VolunteerEmail = userDTO.Email;
        }

    }
}
