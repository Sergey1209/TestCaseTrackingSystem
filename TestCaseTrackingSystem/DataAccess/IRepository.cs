using System.Linq;

namespace DataAccess
{
    public interface IRepository<out T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetById(int id);
    }
}
