using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

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
                    .Include(t => t.AssignedTo)
                    .Include(t => t.CreatedBy);
        }

        public BacklogItem GetBacklogItemById(int id)
        {
            return TctsDataContext.BacklogItems
                .Include(t => t.AssignedTo)
                .Include(t => t.CreatedBy)
                .First(t => t.ID == id);
        }

        public BacklogItem GetBacklogItemByTitle(string title)
        {
            return TctsDataContext.BacklogItems.FirstOrDefault(t => t.Title == title);
        }
    }
}
