using System.Collections.Generic;
using Services.DTO;

namespace Services.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void DeleteUser(int id);
        void AddNew(UserDto user);
        void Update(UserDto user);
    }
}
