using Online_Store_Backend.Domain.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Users.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetById(long id);
        Task<List<UserDto>> GetAll();
        Task<long> InsertUser(UserDto user);
        Task<bool> UpdateUser(UserDto user);
        Task<bool> DeleteUser(long id);
    }
}
