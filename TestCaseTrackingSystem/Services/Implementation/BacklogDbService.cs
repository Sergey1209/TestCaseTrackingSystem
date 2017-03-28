using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementation
{
    public class BacklogDbService : DbServiceBase<BacklogItemDto>, IBacklogService
    {
        public BacklogDbService(ITCTSUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<BacklogItemDto> GetAllBacklogItems()
        {
            return UnitOfWork.BacklogItemRepository.GetAllBacklogItems().Select(ConvertToDto);
        }

        public BacklogItemDto GetBacklogItemById(int id)
        {
            return ConvertToDto(UnitOfWork.BacklogItemRepository.GetBacklogItemById(id));
        }

        public void DeleteBacklogItem(int id)
        {
            UnitOfWork.BacklogItemRepository.RemoveById(id);
            UnitOfWork.Save();
        }

        public void AddNew(BacklogItemDto backlogItem)
        {
            UnitOfWork.BacklogItemRepository.Add(ConvertFromDto(backlogItem));
            UnitOfWork.Save();
        }

        public void Update(BacklogItemDto backlogItem)
        {
            UnitOfWork.BacklogItemRepository.Update(ConvertFromDto(backlogItem));
            UnitOfWork.Save();
        }

        public override bool HasAny()
        {
            return UnitOfWork.BacklogItemRepository.HasAny();
        }

        private static BacklogItemDto ConvertToDto(BacklogItem backlog)
        {
            return new BacklogItemDto
            {
                ID = backlog.ID,
                Title = backlog.Title,
                Description = backlog.Description,
                AssignedToUserID = backlog.AssignedToID,
                AssignedTo = backlog.AssignedTo.Login,
                DateCreated = backlog.DateCreated,
                IterationID = backlog.Iteration?.ID,
                Iteration = backlog.Iteration?.Name,
                Type = backlog.Type,
                UserCreatedID = backlog.CreatedByID,
                UserCreated = backlog.CreatedBy.Login
            };
        }

        private static BacklogItem ConvertFromDto(BacklogItemDto backlogItemDto)
        {
            return new BacklogItem
            {
                ID = backlogItemDto.ID,
                Title = backlogItemDto.Title,
                Description = backlogItemDto.Description,
                AssignedToID = backlogItemDto.AssignedToUserID,
                DateCreated = backlogItemDto.DateCreated,
                IterationID = backlogItemDto.IterationID,
                Type = backlogItemDto.Type,
                CreatedByID = backlogItemDto.UserCreatedID
            };
        }
    }
}
