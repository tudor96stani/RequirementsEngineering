using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO Get(Guid Id);
        List<RoleDTO> GetAllRoles();
    }
}
