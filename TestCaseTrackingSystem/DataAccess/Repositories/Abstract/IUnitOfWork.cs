using System;

namespace DataAccess.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ITestCaseRepository TestCaseRepository { get; }

        int Save();
    }
}
