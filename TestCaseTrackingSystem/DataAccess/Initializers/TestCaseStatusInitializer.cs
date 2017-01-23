using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    public class TestCaseStatusInitializer : EntityInitializerBase<TestCaseStatus>
    {
        protected override IEnumerable<TestCaseStatus> BuiltInEntities => new[]
        {
            new TestCaseStatus
            {
                ID = 1,
                Name = "Not Started"
            }, 
            new TestCaseStatus
            {
                ID = 2,
                Name = "In Progress"
            }, 
            new TestCaseStatus
            {
                ID = 3,
                Name = "Failed"
            }, 
            new TestCaseStatus
            {
                ID = 4,
                Name = "Passed"
            }, 
        };
    }
}
