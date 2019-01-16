using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class OrganizationHomepageViewModel
    {
        public List<TopCandidateViewModel> topCandidates { get; set; }
        public List<OfferQuickDetailsViewModel> orderedOffers { get; set; }

    }
}