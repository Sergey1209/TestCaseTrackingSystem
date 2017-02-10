using DataAccess.Entities;

namespace DataAccess.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string login);
    }
}
