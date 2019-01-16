using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class CandidateDTO
    {
        public Guid CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public double CandidateRating { get; set; }

        public CandidateDTO(UserDTO userDTO)
        {
            CandidateId = userDTO.Id;
            CandidateName = userDTO.FullName;
            CandidateEmail = userDTO.Email;
        }

    }
}
