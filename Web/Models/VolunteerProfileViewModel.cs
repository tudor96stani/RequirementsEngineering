using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VolunteerProfileViewModel
    {
        public Guid VolunteerId { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerEmail { get; set; }
        public double VolunteerRating { get; set; }

        public VolunteerProfileViewModel(VolunteerDTO dto)
        {
            VolunteerId = dto.VolunteerId;
            VolunteerName = dto.VolunteerName;
            VolunteerEmail = dto.VolunteerEmail;
            VolunteerRating = dto.VolunteerRating;
        }
    }
}