using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementation
{
    public class UserDbService : DbServiceBase<UserDto>, IUserService
    {
        public UserDbService(ITCTSUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return UnitOfWork.UserRepository.GetAllUsers().Select(ConvertToDto);
        }

        public UserDto GetUserById(int id)
        {
            return ConvertToDto(UnitOfWork.UserRepository.GetUserById(id));
        }

        public void DeleteUser(int id)
        {
            UnitOfWork.UserRepository.RemoveById(id);
            UnitOfWork.Save();
        }

        public void AddNew(UserDto user)
        {
            UnitOfWork.UserRepository.Add(ConvertFromDto(user));
            UnitOfWork.Save();
        }

        public void Update(UserDto user)
        {
            UnitOfWork.UserRepository.Update(ConvertFromDto(user));
            UnitOfWork.Save();
        }

        private static UserDto ConvertToDto(User user)
        {
            return new UserDto
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
                LastLogin = user.LastLogin
            };
        }

        private static User ConvertFromDto(UserDto user)
        {
            return new User
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
                LastLogin = user.LastLogin
            };
        }
    }
}
