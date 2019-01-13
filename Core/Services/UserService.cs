using Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using System.Data.Entity;
using Core.Utils;
using Core.DAL;

namespace Core.Services
{
   
public class UserService : IUserService
    {
        
        public UserService()
        {
            
        }
        public UserDTO Get(Guid Id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                return _dbContext.AspNetUsers.FirstOrDefault(x => x.Id.Equals(Id.ToString())).ToDTO();
            }
        }

        public List<UserDTO> GetAll()
        {
        
            using (var _dbContext = new ApplicationDbContext())
            {
                return _dbContext.AspNetUsers.AsEnumerable().Select(x => x.ToDTO()).ToList();
            }
        }

        public List<RoleDTO> GetAllRoles()
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                return _dbContext.AspNetRoles.AsEnumerable().Select(x => x.ToDTO()).ToList();
            }
        }
    }
}