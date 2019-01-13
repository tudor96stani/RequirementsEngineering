using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class OrganizationHomepageViewModel
    {
        public List<TopVolunteerViewModel> topVolunteers { get; set; }
        public List<EventQuickDetailsViewModel> orderedEvents { get; set; }

    }
}