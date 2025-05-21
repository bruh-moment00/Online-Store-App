using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Online_Store_Backend.Core.AuthModels;
using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Employees.Models;
using Online_Store_Backend.Database.Users.Models;
using Online_Store_Backend.Domain.Authentication.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_Store_Backend.Domain.Authentication
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IRepositoryAsync<User> userRepository;
        private readonly IRepositoryAsync<Employee> employeeRepository;
        private readonly IConfiguration configuration;
        public UserAuthService(IRepositoryAsync<User> userRepository, IRepositoryAsync<Employee> employeeRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.employeeRepository = employeeRepository;
            this.configuration = configuration;
        }

        public async Task<string> ValidateAndGetUserToken(UserAuth userData)
        {
            var users = await userRepository.Filter(u => u.Email == userData.Email || 
                u.PhoneNum == userData.PhoneNum || u.Login == userData.Login);
            var user = users.First();

            UserTokenData userToken = new UserTokenData()
            {
                Id = user.ID,
                Password = userData.Password
            };

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(userData.Password, user.PasswordHash))
                {
                    var token = GenerateJwtToken(userToken);
                    return token;
                }
            }

            return null;
        }

        public async Task<string> ValidateAndGetEmployeeToken(UserAuth employeeData)
        {
            var employees = await employeeRepository.Filter(u => u.Email == employeeData.Email ||
                u.PhoneNum == employeeData.PhoneNum || u.Login == employeeData.Login);
            var employee = employees.First();

            UserTokenData employeeToken = new UserTokenData()
            {
                Id = employee.ID,
                Password = employeeData.Password
            };

            if (employee != null)
            {
                if (BCrypt.Net.BCrypt.Verify(employeeData.Password, employee.PasswordHash))
                {
                    var token = GenerateJwtToken(employeeToken);
                    return token;
                }
            }

            return null;
        }

        private string GenerateJwtToken(UserTokenData user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
