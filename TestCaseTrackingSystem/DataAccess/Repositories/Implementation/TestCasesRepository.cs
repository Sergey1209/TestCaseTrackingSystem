using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Implementation
{
    public class TestCasesRepository : RepositoryBase<TestCase>, ITestCaseRepository
    {
        public TestCasesRepository(TestCaseDataContext context) : base(context)
        {
        }

        public IEnumerable<TestCase> GetAllBacklogItemTestCases(int backlogItemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestCase> GetBacklogItemTestCases(int backlogItemId, Expression<Func<TestCase, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestCase> GetAllTestCasesAssignedToUser(int userId)
        {
            throw new NotImplementedException();
        }

        private TestCaseDataContext TestCaseDataContext => (TestCaseDataContext)Context;
    }
}
