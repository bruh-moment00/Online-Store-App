using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Online_Store_Backend.Core.AuthModels;
using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Employees.Models;
using Online_Store_Backend.Database.Users.Models;
using Online_Store_Backend.Domain.Authentication.Interfaces;
using Online_Store_Backend.Domain.Users.Dto;
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
            IEnumerable<User> users;
            if (userData.PhoneNum != null) users = await userRepository.Filter(u => u.PhoneNum == userData.PhoneNum);
            else if (userData.Email != null) users = await userRepository.Filter(u => u.Email == userData.Email);
            else if (userData.Login != null) users = await userRepository.Filter(u => u.Login == userData.Login);
            else return null;
            var user = users.FirstOrDefault();

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(userData.Password, user.PasswordHash))
                {
                    var token = GenerateJwtToken(user.ID, "user");
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

        public async Task<bool> ValidateUserTokenAsync(string token)
        {
            var userToken = await userTokenRepository.Filter(ut => ut.Token == token && DateTime.UtcNow < ut.ExpirationDate);
            return userToken.Any();
        }

        public async Task<bool> ValidateEmployeeTokenAsync(string token)
        {
            var employeeToken = await employeeTokenRepository.Filter(et => et.Token == token && DateTime.UtcNow < et.ExpirationDate);
            return employeeToken.Any();
        }

        public async Task<string?> ValidateAndGetEmployeeTokenAsync(AuthData employeeData)
        {
            IEnumerable<Employee> employees;
            if (employeeData.PhoneNum != null) employees = await employeeRepository.Filter(u => u.PhoneNum == employeeData.PhoneNum);
            else if (employeeData.Email != null) employees = await employeeRepository.Filter(u => u.Email == employeeData.Email);
            else if (employeeData.Login != null) employees = await employeeRepository.Filter(u => u.Login == employeeData.Login);
            else return null;

            var employee = employees.FirstOrDefault();

            if (employee != null)
            {
                if (BCrypt.Net.BCrypt.Verify(employeeData.Password, employee.PasswordHash))
                {
                    var token = GenerateJwtToken(employee.ID, "employee");
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

        private string GenerateJwtToken(long id, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim("id", id.ToString()),
                }),

                Expires = DateTime.UtcNow.AddDays(30),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
