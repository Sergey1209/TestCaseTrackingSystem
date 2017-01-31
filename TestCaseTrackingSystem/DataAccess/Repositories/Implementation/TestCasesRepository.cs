using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;
using System.Data.Entity;

namespace DataAccess.Repositories.Implementation
{
    public class TestCasesRepository : RepositoryBase<TestCase>, ITestCaseRepository
    {
        public TestCasesRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TestCase> GetAllBacklogItemTestCases(int backlogItemId)
        {
            return TestCaseDataContext.TestCases
                .Include(t => t.Status)
                .Where(t => t.BacklogItemID == backlogItemId);
        }

        public IEnumerable<TestCase> GetBacklogItemTestCases(int backlogItemId, Expression<Func<TestCase, bool>> predicate)
        {
            return TestCaseDataContext.TestCases.Where(t => t.BacklogItemID == backlogItemId).Where(predicate);
        }

        private TestCaseDataContext TestCaseDataContext => (TestCaseDataContext)Context;
    }
}
