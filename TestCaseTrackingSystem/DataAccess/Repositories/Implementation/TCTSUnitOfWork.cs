using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class TCTSUnitOfWork : ITCTSUnitOfWork
    {
        private readonly TCTSDataContext _context;

        public TCTSUnitOfWork(TCTSDataContext context)
        {
            _context = context;
            TestCaseRepository = new TestCasesRepository(_context);
            UserRepository = new UserRepository(_context);
            IterationRepository = new IterationRepository(_context);
            BacklogItemRepository = new BacklogItemRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ITestCaseRepository TestCaseRepository { get; }
        public IUserRepository UserRepository { get; }
        public IIterationRepository IterationRepository { get; }
        public IBacklogItemRepository BacklogItemRepository { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
