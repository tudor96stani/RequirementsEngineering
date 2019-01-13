using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTO;

namespace Web.Models
{
    public class EventEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserBasicViewModel Owner { get; set; }
        public List<UserBasicViewModel> Participants { get; set; }
        public string Location { get; set; }
        public string LocationId { get; set; }

       
        [DataType(DataType.DateTime, ErrorMessage = "This is not a valid DateTime")]
        public DateTime DateTimeUtc { get; set; }
        public string Description { get; set; }
        public List<SelectListItem> LocationList { get; set; }

        public EventEditViewModel(EventDTO dto, List<SelectListItem> locationList)
        {
            Id = dto.Id;
            Name = dto.Name;
            Owner = new UserBasicViewModel(dto.Owner);
            Participants = dto.Participants.Select(x => new UserBasicViewModel(x)).ToList();
            Location = dto.Location.City + ", " + dto.Location.Country + ", " + dto.Location.Street + " " +
                       dto.Location.Number;
            LocationId = dto.Location.Id;

            DateTimeUtc =dto.DateTimeUtc;
            Description = dto.Description;
            LocationList = locationList;


        }

        public EventEditViewModel()
        {
                
        }
    }
}