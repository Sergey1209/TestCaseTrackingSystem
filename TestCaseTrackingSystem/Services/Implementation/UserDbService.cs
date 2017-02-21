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
            throw new System.NotImplementedException();
        }

        public void AddNew(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public void Update(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        private static UserDto ConvertToDto(User user)
        {
            return new UserDto
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Role = (UserRoleEnum)user.Role.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateCreated = user.CreatedDate,
                LastLoginDate = user.LastLogin
            };
        }

        private static Iteration ConvertFromDto(IterationDto dtoIteration)
        {
            return new Iteration
            {
                ID = dtoIteration.ID,
                Name = dtoIteration.Name,
                StartDate = dtoIteration.StartDate,
                EndDate = dtoIteration.EndDate
            };
        }
    }
}
