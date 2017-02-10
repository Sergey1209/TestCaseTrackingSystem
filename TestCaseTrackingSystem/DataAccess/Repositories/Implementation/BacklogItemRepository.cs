using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Implementation
{
    public class BacklogItemRepository : RepositoryBase<BacklogItem>, IBacklogItemRepository
    {
        public BacklogItemRepository(DbContext context) : base(context)
        {
        }

        private TCTSDataContext TctsDataContext => (TCTSDataContext)Context;
        public IEnumerable<BacklogItem> GetAllBacklogItems()
        {
            return
                TctsDataContext.BacklogItems
                    .Include(t => t.Type)
                    .Include(t => t.AssignedTo)
                    .Include(t => t.CreatedBy)
                    .Include(t => t.Iteration);
        }

        public BacklogItem GetBacklogItemById(int id)
        {
            return TctsDataContext.BacklogItems
                .Include(t => t.Type)
                .Include(t => t.AssignedTo)
                .Include(t => t.CreatedBy)
                .Include(t => t.Iteration)
                .First(t => t.ID == id);
        }
    }
}
