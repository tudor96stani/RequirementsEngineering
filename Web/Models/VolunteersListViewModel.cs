using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Web.Models
{
    public class VolunteersListViewModel
    {
        public Guid EventId { get; set; }
        public List<UserBasicViewModel> Participants { get; set; }

        public VolunteersListViewModel(Guid eventId, List<UserBasicViewModel> participants)
        {
            EventId = eventId;
            Participants = participants;
        }


    }


}