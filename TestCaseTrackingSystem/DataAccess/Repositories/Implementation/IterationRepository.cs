using System.Data.Entity;
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
    }
}
