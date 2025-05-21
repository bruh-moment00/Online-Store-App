using Online_Store_Backend.Core.AuthModels;

namespace Online_Store_Backend.Domain.Authentication.Interfaces
{
    public interface IUserAuthService
    {
        Task<string> ValidateAndGetUserToken(UserAuth userData);
        Task<string> ValidateAndGetEmployeeToken(UserAuth employeeData);
    }
}
