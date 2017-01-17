using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess
{
    public class TestCaseDataContext : DbContext
    {
        public TestCaseDataContext() : base("TestCaseTrackingSystem")
        { }

        public DbSet<BacklogItemType> BakItemTypes { get; set; }
    }
}
