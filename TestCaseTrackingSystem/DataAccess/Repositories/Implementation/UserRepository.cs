using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return TctsDataContext.Users.Include(t => t.Role);
        }

        public User GetUserById(int id)
        {
            return TctsDataContext.Users.Include(t => t.Role).FirstOrDefault(t => t.ID == id);
        }

        public User GetUserByLogin(string login)
        {
            return TctsDataContext.Users.Include(t => t.Role).FirstOrDefault(t => t.Login == login);
        }

        private TCTSDataContext TctsDataContext => (TCTSDataContext)Context;
    }
}
