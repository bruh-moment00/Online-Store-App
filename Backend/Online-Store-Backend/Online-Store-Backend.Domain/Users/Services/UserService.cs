using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Users.Models;
using Online_Store_Backend.Domain.Users.Dto;
using Online_Store_Backend.Domain.Users.Services.Interfaces;

namespace Online_Store_Backend.Domain.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<User> userRepository;
        public UserService(IRepositoryAsync<User> userRepository) => this.userRepository = userRepository;

        public async Task<UserDto> GetById(long id)
        {
            var user = await userRepository.FindById(id);
            return user == null ? null : EntityToDtoMapping(user);
        }
        public async Task<List<UserDto>> GetAll()
        {
            var users = await userRepository.Filter(x => x.IsActive && !x.IsDeleted);
            return users.Select(EntityToDtoMapping).ToList();
        }
        public async Task<long> InsertUser(UserDto user)
        {
            var entity = DtoToEntityMapping(user);
            return await userRepository.Insert(entity);
        }
        public async Task<bool> UpdateUser(UserDto user)
        {
            var entity = DtoToEntityMapping(user);
            return await userRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteUser(long id) => await userRepository.Delete(id);

        private static UserDto EntityToDtoMapping(User user)
        {
            return new UserDto
            {
                ID = user.ID,
                CreatedDateTime = user.CreatedDateTime,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                PhoneNum = user.PhoneNum,
                Login = user.Login,
                PasswordHash = user.PasswordHash
            };
        }
        private static User DtoToEntityMapping(UserDto user)
        {
            return new User
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNum = user.PhoneNum,
                Gender = user.Gender,
                Login = user.Login,
            };
        }
    }
}
