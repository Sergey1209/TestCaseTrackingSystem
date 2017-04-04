using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions;
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
            UnitOfWork.UserRepository.RemoveUserById(id);
            UnitOfWork.Save();
        }

        public void AddNew(UserDto user)
        {
            if (UnitOfWork.UserRepository.GetUserByLogin(user.Login) == null)
            {
                UnitOfWork.UserRepository.Add(ConvertFromDto(user));
                UnitOfWork.Save();
            }
            else
            {
                throw new DuplicateUserException();
            }
        }

        public void Update(UserDto user)
        {
            UnitOfWork.UserRepository.Update(ConvertFromDto(user));
            UnitOfWork.Save();
        }

        public void UpdateLastLoginDate(string login)
        {
            UnitOfWork.UserRepository.GetUserByLogin(login).LastLogin = DateTime.Now;
            UnitOfWork.Save();
        }

        public override bool HasAny()
        {
            return UnitOfWork.UserRepository.HasAny();
        }

        private static UserDto ConvertToDto(User user)
        {
            return new UserDto
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
                Position = user.Position,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Skype = user.Skype,
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
                Position = user.Position,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Skype = user.Skype,
                CreatedDate = user.CreatedDate,
                LastLogin = user.LastLogin
            };
        }
    }
}
