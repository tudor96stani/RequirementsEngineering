using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CandidateHomepageViewModel
    {
        public List<TopOrganizationViewModel> topOrganizations { get; set; }
        public List<OfferQuickDetailsViewModel> orderedOffers { get; set; }
        public List<LocationSelectorViewModel> Locations { get; set; }
    }
}