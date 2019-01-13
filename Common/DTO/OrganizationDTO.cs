using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class OrganizationDTO
    {
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationEmail { get; set; }
        public double OrganizationRating { get; set; }

        public OrganizationDTO(UserDTO userDTO)
        {
            OrganizationId = userDTO.Id;
            OrganizationName = userDTO.FullName;
            OrganizationEmail = userDTO.Email;
        }
    }
}
