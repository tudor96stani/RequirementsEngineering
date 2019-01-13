using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventQuickDetailsViewModel
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }
        public List<string> Donations { get; set; }
        public string DateTimeUTC { get; set; }

        public EventQuickDetailsViewModel(EventQuickInfoDTO dto)
        {
            Id = dto.Id;
            OwnerId = dto.Owner.Id;
            Name = dto.Name;
            Location = $"{dto.Location.Street} no. {dto.Location.Number},{dto.Location.City},{dto.Location.Country}";
            Owner = dto.Owner.FullName;
            Donations = dto.Donations.Select(x => x.Donor.FullName + " - $" + x.Amount).ToList();
            DateTimeUTC = dto.DateTimeUTC.ToString();
        }
    }
}