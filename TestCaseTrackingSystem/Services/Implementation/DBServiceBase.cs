using DataAccess.Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public abstract class DbServiceBase<T> : IService<T> where T : IDto
    {
        protected ITCTSUnitOfWork UnitOfWork { get; }

        protected DbServiceBase(ITCTSUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public abstract bool HasAny();
    }
}
