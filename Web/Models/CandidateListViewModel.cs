using System;
using System.Collections.Generic;
using System.Diagnostics.Offering.Reader;

namespace Web.Models
{
    public class CandidatesListViewModel
    {
        public Guid OfferId { get; set; }
        public List<UserBasicViewModel> Participants { get; set; }

        public CandidatesListViewModel(Guid offerId, List<UserBasicViewModel> participants)
        {
            OfferId = offerId;
            Participants = participants;
        }


    }


}