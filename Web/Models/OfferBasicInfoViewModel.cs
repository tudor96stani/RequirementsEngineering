using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.DTO;

namespace Web.Models
{
    public class OfferBasicInfoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string DateTimeV { get; set; }
        public DateTime DateTimeUTC(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day, 0, 0, 0);
            return date;
        }

        public OfferBasicInfoViewModel(OfferDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            DateTimeV = DateTimeUTC(dto.DateTimeUtc.Year, dto.DateTimeUtc.Month, dto.DateTimeUtc.Day).ToString("yyyy-MM-dd");
        }
    }
}