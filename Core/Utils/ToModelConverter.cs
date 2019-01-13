﻿using Common.DTO;
using Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    internal static class ToModelConverter
    {
        public static AspNetUser ToModel(this UserDTO user)
        {
            return user == null ? null : new AspNetUser()
            {
                Id=user.Id.ToString(),
                UserName = user.Username,
                Email = user.Email,
                FullName = user.FullName
            };
        }
        public static AspNetRole ToModel(this RoleDTO role)
        {
            return role == null ? null : new AspNetRole()
            {
                Id = role.Id.ToString(),
                Name = role.Name
            };
        }

        public static Event ToModel(this EventDTO ev)
        {
            return ev == null ? null : new Event()
            {
                Id = ev.Id.ToString(),
                Name = ev.Name,
                Owner = ev.Owner.ToModel(),
                OwnerId=ev.Owner.Id.ToString(),
                Participants = ev.Participants.Select(x => x.ToModel()).ToList(),
                Donations = ev.Donations.Select(x => x.ToModel()).ToList(),
                Location=ev.Location.ToModel(),
                LocationId=ev.Location.Id,
                DateTimeUTC = ev.DateTimeUtc,
                Description = ev.Description
            };
        }

        public static Donation ToModel(this DonationDTO donation)
        {
            return donation == null ? null : new Donation()
            {
                Id = donation.Id,
                AspNetUser = donation.User.ToModel(),
                EventId = donation.EventId.ToString(),
                Amount = donation.Amount
            };
        }

        public static Location ToModel(this LocationDTO loc)
        {
            return loc == null ? null : new Location()
            {
                Id = loc.Id,
                Country = loc.Country,
                City = loc.City,
                Street = loc.Street,
                Number = loc.Number
            };

        }

        public static Rating ToModel(this RatingDTO rating)
        {
            return rating == null ? null : new Rating()
            {
                Id = rating.Id,
                UserId = rating.UserId.ToString(),
                Rating1 = (int)rating.Rating
            };

        }

        public static File ToModel(this FileDTO file)
        {
            return file == null ? null : new File()
            {
                Id = file.Id,
                UserId = file.UserId,
                OriginalName = file.OriginalName,
                Extension = file.Extension
            };
        }
    }
}
