using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestCaseDataContext _context;

        public UnitOfWork(TestCaseDataContext context)
        {
            _context = context;
            TestCaseRepository = new TestCasesRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ITestCaseRepository TestCaseRepository { get; }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
