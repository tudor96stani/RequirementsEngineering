using Common.DTO;
using Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    internal static class ToDTOConverter
    {
        public static UserDTO ToDTO(this AspNetUser user)
        {
            return user == null ? null : new UserDTO()
            {
                Id=new Guid(user.Id),
                Username = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Ratings = user.Ratings.Select(x=>x.ToDTO()).ToList(),
                Files = user.Files.Select(x=>x.ToDTO()).ToList()
            };
        }
        public static RoleDTO ToDTO(this AspNetRole role)
        {
            return role == null ? null : new RoleDTO()
            {
                Id=new Guid(role.Id),
                Name=role.Name
            };
        }



        public static OfferDTO ToDTO(this Offer ev)
        {
            return ev == null ? null : new OfferDTO()
            {
                Id = new Guid(ev.Id),
                Name = ev.Name,
                Owner = ev.Owner.ToDTO(),
                Participants = ev.Participants.Select(x => x.ToDTO()).ToList(),
                Location = ev.Location.ToDTO(),
                DateTimeUtc= (DateTime)ev.DateTimeUTC,
                Description = ev.Description
            };
        }

 
        public static LocationDTO ToDTO(this Location loc)
        {
            return loc == null ? null : new LocationDTO()
            {
                Id=loc.Id,
                Country=loc.Country,
                City=loc.City,
                Street=loc.Street,
                Number=loc.Number
            };

        }

        public static RatingDTO ToDTO(this Rating rating)
        {
            return rating == null ? null : new RatingDTO()
            {
                Id=rating.Id,
                UserId=new Guid(rating.UserId),
                Rating= (int)rating.Rating1
            };

        }

        public static FileDTO ToDTO(this File file)
        {
            return file == null ? null : new FileDTO()
            {
                Id = file.Id,
                UserId = file.UserId,
                OriginalName = file.OriginalName,
                Extension = file.Extension
            };
        }
    }
}
