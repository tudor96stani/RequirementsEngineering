using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CandidateProfileViewModel
    {
        public Guid CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public double CandidateRating { get; set; }

        public CandidateProfileViewModel(CandidateDTO dto)
        {
            CandidateId = dto.CandidateId;
            CandidateName = dto.CandidateName;
            CandidateEmail = dto.CandidateEmail;
            CandidateRating = dto.CandidateRating;
        }
    }
}