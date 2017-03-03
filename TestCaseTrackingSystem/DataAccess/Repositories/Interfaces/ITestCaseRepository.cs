using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestCaseRepository : IRepository<TestCase>
    {
        IEnumerable<TestCase> GetAllTestCases();
        TestCase GetTestCaseById(int id);
        IEnumerable<TestCase> GetAllBacklogItemTestCases(int backlogItemId);
        IEnumerable<TestCase> GetBacklogItemTestCases(int backlogItemId, Expression<Func<TestCase, bool>> predicate);
    }
}
