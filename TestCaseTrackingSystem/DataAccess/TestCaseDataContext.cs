using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Initializers;

namespace DataAccess
{
    public class TestCaseDataContext : DbContext
    {
        static TestCaseDataContext()
        {
            Database.SetInitializer(new TestCaseDataContextInitializer());
        }

        public TestCaseDataContext() : base("TestCaseTrackingSystem")
        { }

        public DbSet<BacklogItemType> BacklogItemTypes { get; set; }
    }
}
