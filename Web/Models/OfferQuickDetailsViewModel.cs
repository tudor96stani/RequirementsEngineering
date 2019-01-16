using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class OfferQuickDetailsViewModel
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }
        public string DateTimeUTC { get; set; }

        public OfferQuickDetailsViewModel(OfferQuickInfoDTO dto)
        {
            Id = dto.Id;
            OwnerId = dto.Owner.Id;
            Name = dto.Name;
            Location = $"{dto.Location.Street} no. {dto.Location.Number},{dto.Location.City},{dto.Location.Country}";
            Owner = dto.Owner.FullName;
            DateTimeUTC = dto.DateTimeUTC.ToString();
        }
    }
}