using Online_Store_Backend.Domain.Authentication.Dto;
using Online_Store_Backend.Domain.Users.Dto;

namespace Online_Store_Backend.Domain.Users.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetById(long id);
        Task<List<UserDto>> GetAll();
        Task<long> InsertUser(UserPostDto user);
        Task<bool> UpdateUser(UserDto user);
        Task<bool> ChangePassword(PasswordDto passwordDto);
        Task<bool> DeleteUser(long id);
    }
}
