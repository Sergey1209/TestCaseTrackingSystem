using System.Data.Entity;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class IterationRepository : RepositoryBase<Iteration>, IIterationRepository
    {
        public IterationRepository(DbContext context) : base(context)
        {
        }

        private TCTSDataContext TctsDataContext => (TCTSDataContext)Context;
        public void RemoveIterationById(int id)
        {
            TctsDataContext.BacklogItems.Where(t => t.IterationID == id).Load();
            TctsDataContext.Iterations.Remove(TctsDataContext.Iterations.Find(id));
        }
    }
}
