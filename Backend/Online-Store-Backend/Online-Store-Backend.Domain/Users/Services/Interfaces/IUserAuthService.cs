using Online_Store_Backend.Core.AuthModels;

namespace Online_Store_Backend.Domain.Users.Services.Interfaces
{
    public interface IUserAuthService
    {
        Task<string> ValidateAndGetUserToken(UserAuth user);
    }
}
