using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repositories.Abstract
{
    public interface ITestCaseRepository : IRepository<TestCase>
    {
        IEnumerable<TestCase> GetAllBacklogItemTestCases(int backlogItemId);
        IEnumerable<TestCase> GetBacklogItemTestCases(int backlogItemId, Expression<Func<TestCase, bool>> predicate);
    }
}
