using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VolunteerHomepageViewModel
    {
        public List<TopOrganizationViewModel> topOrganizations { get; set; }
        public List<EventQuickDetailsViewModel> orderedEvents { get; set; }
        public List<LocationSelectorViewModel> Locations { get; set; }
    }
}