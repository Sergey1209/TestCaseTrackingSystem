using System.Collections.Generic;
using Services.DTO;

namespace Services.Interfaces
{
    public interface IIterationService : IService<IterationDto>
    {
        IEnumerable<IterationDto> GetAllIterations();
        IterationDto GetIterationById(int id);
        void DeleteIteration(int id);
        void AddNew(IterationDto iteration);
        void Update(IterationDto iteration);
    }
}
