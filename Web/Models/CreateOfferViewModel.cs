using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CreateOfferViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public Guid OwnerId { get; set; }
        public string Description { get; set; }
        public int CandidatesGoals { get; set; }
    }
}