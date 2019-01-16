using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.DTO;
using System.Data.Entity;
namespace Web.Models
{
    public class TopCandidateViewModel
    {
        public int CandidateRating { get; set; }
        public string CandidateName { get; set; }
        public Guid CandidateId { get; set; }

        public TopCandidateViewModel(UserDTO user)
        {
            if(user.Ratings.Select(x => x.Rating).ToList().Count == 0)
            {
                CandidateRating = 0;
            }
            else
            {
                CandidateRating = (int)user.Ratings.Select(x => x.Rating).Average();
            }
            CandidateName = user.FullName;
            CandidateId = user.Id;
        }
    }
}