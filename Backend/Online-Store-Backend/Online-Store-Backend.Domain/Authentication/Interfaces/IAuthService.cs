using Online_Store_Backend.Core.AuthModels;

namespace Online_Store_Backend.Domain.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<string?> ValidateAndGetUserTokenAsync(AuthData userData);
        Task<string?> ValidateAndGetEmployeeTokenAsync(AuthData employeeData);
        Task<bool> ValidateUserTokenAsync(string token);
        Task<bool> ValidateEmployeeTokenAsync(string token);
    }
}
