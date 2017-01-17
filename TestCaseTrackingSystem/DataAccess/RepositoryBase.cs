using System;
using System.Linq;

namespace DataAccess
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        public IQueryable<T> GetAll()
        {
            using (var context = new TestCaseDataContext())
            {
                context.
            }
        }

        public IQueryable<T> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
