using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class TestCaseStatusInitializer : EntityInitializerBase<TestCaseStatus>
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
            }
        };

        public override void InitializeModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestCaseStatus>().HasKey(t => t.ID).Property(t => t.ID).IsRequired();
            modelBuilder.Entity<TestCaseStatus>().Property(t => t.Name).IsRequired();
        }
    }
}
