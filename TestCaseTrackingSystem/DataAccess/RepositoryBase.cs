using System;
using System.Linq;

namespace DataAccess
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
