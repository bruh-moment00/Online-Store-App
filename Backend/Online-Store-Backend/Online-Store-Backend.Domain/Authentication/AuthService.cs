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
    public class AuthService : IAuthService
    {
        private readonly IRepositoryAsync<User> userRepository;
        private readonly IRepositoryAsync<Employee> employeeRepository;
        private readonly IRepositoryAsync<UserToken> userTokenRepository;
        private readonly IRepositoryAsync<EmployeeToken> employeeTokenRepository;
        private readonly IConfiguration configuration;
        public AuthService(IRepositoryAsync<User> userRepository,
                               IRepositoryAsync<Employee> employeeRepository,
                               IRepositoryAsync<UserToken> userTokenRepository,
                               IRepositoryAsync<EmployeeToken> employeeTokenRepository,
                               IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.employeeRepository = employeeRepository;
            this.userTokenRepository = userTokenRepository;
            this.employeeTokenRepository = employeeTokenRepository;
            this.configuration = configuration;
        }

        public async Task<string?> ValidateAndGetUserTokenAsync(AuthData userData)
        {
            var users = await userRepository.Filter(u => u.Email == userData.Email || 
                u.PhoneNum == userData.PhoneNum || u.Login == userData.Login);
            var user = users.FirstOrDefault();

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(userData.Password, user.PasswordHash))
                {
                    var token = GenerateJwtToken(user.ID);
                    await userTokenRepository.Insert(new UserToken
                    {
                        UserID = user.ID,
                        Token = token,
                    });
                    return token;
                }
            }

            return null;
        }

        public async Task<string?> ValidateAndGetEmployeeTokenAsync(AuthData employeeData)
        {
            var employees = await employeeRepository.Filter(u => u.Email == employeeData.Email ||
                u.PhoneNum == employeeData.PhoneNum || u.Login == employeeData.Login);
            var employee = employees.First();

            if (employee != null)
            {
                if (BCrypt.Net.BCrypt.Verify(employeeData.Password, employee.PasswordHash))
                {
                    var token = GenerateJwtToken(employee.ID);
                    await employeeTokenRepository.Insert(new EmployeeToken
                    {
                        EmployeeID = employee.ID,
                        Token = token,
                    });
                    return token;
                }
            }

            return null;
        }

        private string GenerateJwtToken(long id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", id.ToString()),
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
