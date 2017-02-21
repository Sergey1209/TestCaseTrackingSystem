using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementation
{
    public class IterationDbService : DbServiceBase<IterationDto>, IIterationService
    {
        public IterationDbService(ITCTSUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<IterationDto> GetAllIterations()
        {
            return UnitOfWork.IterationRepository.GetAll().Select(ConvertToDto);
        }

        public IterationDto GetIterationById(int id)
        {
            return ConvertToDto(UnitOfWork.IterationRepository.GetById(id));
        }

        public void DeleteIteration(int id)
        {
            UnitOfWork.IterationRepository.Remove(UnitOfWork.IterationRepository.GetById(id));
            UnitOfWork.Save();
        }

        public void AddNew(IterationDto iteration)
        {
            UnitOfWork.IterationRepository.Add(ConvertFromDto(iteration));
            UnitOfWork.Save();
        }

        public void Update(IterationDto iteration)
        {
            UnitOfWork.IterationRepository.Update(ConvertFromDto(iteration));
            UnitOfWork.Save();
        }

        private static IterationDto ConvertToDto(Iteration iteration)
        {
            return new IterationDto
            {
                ID = iteration.ID,
                Name = iteration.Name,
                StartDate = iteration.StartDate,
                EndDate = iteration.EndDate
            };
        }

        private static Iteration ConvertFromDto(IterationDto dtoIteration)
        {
            return new Iteration
            {
                ID = dtoIteration.ID,
                Name = dtoIteration.Name,
                StartDate = dtoIteration.StartDate,
                EndDate = dtoIteration.EndDate
            };
        }
    }
}
