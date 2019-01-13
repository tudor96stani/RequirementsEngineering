using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.DTO;
using System.Data.Entity;
namespace Web.Models
{
    public class TopOrganizationViewModel
    {
        public int OrganizationRating { get; set; }
        public string OrganizationName { get; set; }
        public Guid OrganizationId { get; set; }

        public TopOrganizationViewModel(UserDTO user)
        {
            if (user.Ratings.Select(x => x.Rating).ToList().Count == 0)
            {
                OrganizationRating = 0;
            }
            else
            {
                OrganizationRating = (int)user.Ratings.Select(x => x.Rating).Average();
            }
            OrganizationName = user.FullName;
            OrganizationId = user.Id;
        }
    }
}