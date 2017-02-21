using System;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITCTSUnitOfWork : IDisposable
    {
        ITestCaseRepository TestCaseRepository { get; }

        IUserRepository UserRepository { get; }

        IIterationRepository IterationRepository { get; }

        IBacklogItemRepository BacklogItemRepository { get; }

        int Save();
    }
}
