using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.DTO;
using System.Data.Entity;
namespace Web.Models
{
    public class TopVolunteerViewModel
    {
        public int VolunteerRating { get; set; }
        public string VolunteerName { get; set; }
        public Guid VolunteerId { get; set; }

        public TopVolunteerViewModel(UserDTO user)
        {
            if(user.Ratings.Select(x => x.Rating).ToList().Count == 0)
            {
                VolunteerRating = 0;
            }
            else
            {
                VolunteerRating = (int)user.Ratings.Select(x => x.Rating).Average();
            }
            VolunteerName = user.FullName;
            VolunteerId = user.Id;
        }
    }
}