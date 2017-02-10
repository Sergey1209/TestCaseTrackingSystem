using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Abstract
{
    public interface IBacklogItemRepository : IRepository<BacklogItem>
    {
        IEnumerable<BacklogItem> GetAllBacklogItems();
        BacklogItem GetBacklogItemById(int id);
    }
}
