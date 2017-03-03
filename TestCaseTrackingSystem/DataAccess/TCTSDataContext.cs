using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Initializers;

namespace DataAccess
{
    public class TCTSDataContext : DbContext
    {
        static TCTSDataContext()
        {
            Database.SetInitializer(TCTSDataContextInitializer.Instance);
        }

        public TCTSDataContext() : base("TestCaseTrackingSystem")
        { }

        public DbSet<BacklogItem> BacklogItems { get; set; }
        public DbSet<Iteration> Iterations { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            TCTSDataContextInitializer.Instance.InitializeModels(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
