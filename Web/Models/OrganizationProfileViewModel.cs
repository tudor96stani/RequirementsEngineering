using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class OrganizationProfileViewModel
    {
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationEmail { get; set; }
        public double OrganizationRating { get; set; }

        public OrganizationProfileViewModel(OrganizationDTO dto)
        {
            OrganizationId = dto.OrganizationId;
            OrganizationName = dto.OrganizationName;
            OrganizationEmail = dto.OrganizationEmail;
            OrganizationRating = dto.OrganizationRating;
        }
    }
}