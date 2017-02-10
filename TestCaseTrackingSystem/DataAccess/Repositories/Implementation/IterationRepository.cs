using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Implementation
{
    public class IterationRepository : RepositoryBase<Iteration>, IIterationRepository
    {
        public IterationRepository(DbContext context) : base(context)
        {
        }

        private TCTSDataContext TctsDataContext => (TCTSDataContext)Context;
    }
}
