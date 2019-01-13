using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;
using Common.DTO;

namespace Web.Models
{
    public class EventProfileViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserBasicViewModel Owner { get; set; }
        public List<UserBasicViewModel> Participants { get; set; }
        public string Location { get; set; }
        public string LocationId { get; set; }
        public string DateTimeUtc { get; set; }
        public string Description { get; set; }


        public EventProfileViewModel(EventDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Owner = new UserBasicViewModel(dto.Owner);
            Participants = dto.Participants.Select(x => new UserBasicViewModel(x)).ToList();
            Location = dto.Location.City + ", " + dto.Location.Country + ", " + dto.Location.Street + " " +
                       dto.Location.Number;
            LocationId = dto.Location.Id;
            

            DateTimeUtc = dto.DateTimeUtc.ToString();
            Description = dto.Description;
 

        }
        
    }




}