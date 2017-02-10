using System.Data.Entity;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetByLogin(string login)
        {
            return TctsDataContext.Users.FirstOrDefault(t => t.Login == login);
        }

        private TCTSDataContext TctsDataContext => (TCTSDataContext)Context;
    }
}
