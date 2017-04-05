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
            return TctsDataContext.Users;
        }

        public User GetUserById(int id)
        {
            return TctsDataContext.Users.FirstOrDefault(t => t.ID == id);
        }

        public User GetUserByLogin(string login)
        {
            return TctsDataContext.Users.FirstOrDefault(t => t.Login == login);
        }

        public void RemoveUserById(int id)
        {
            TctsDataContext.TestCases.Where(t => t.CreatedByID == id || t.AssignedToID == id).Load();
            TctsDataContext.BacklogItems.Where(t => t.CreatedByID == id || t.AssignedToID == id).Load();
            TctsDataContext.Users.Remove(TctsDataContext.Users.Find(id));
        }

        private TCTSDataContext TctsDataContext => (TCTSDataContext)Context;
    }
}
