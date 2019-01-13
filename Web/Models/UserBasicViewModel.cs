using System;
using System.Linq;
using System.Reflection.Emit;
using Common.DTO;

namespace Web.Models
{
    public class UserBasicViewModel
    {
        public Guid Id { get; set; }
        public string FullName{ get; set; }

        public double Rating { get; set; }


        public UserBasicViewModel(UserDTO dto)
        {
            Id = dto.Id;
            FullName = dto.FullName;
            Rating =(double)  dto.Ratings.Sum(x=>x.Rating)/dto.Ratings.Count;
        }
    }
}