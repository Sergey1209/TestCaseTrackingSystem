using System.Collections.Generic;
using Services.DTO;

namespace Services.Interfaces
{
    public interface IBacklogService : IService<BacklogItemDto>
    {
        IEnumerable<BacklogItemDto> GetAllBacklogItems();
        BacklogItemDto GetBacklogItemById(int id);
        void DeleteBacklogItem(int id);
        void AddNew(BacklogItemDto backlogItem);
        void Update(BacklogItemDto backlogItem);
    }
}
