using System.Data.Entity;

namespace DataAccess.Initializers
{
    internal interface IEntityInitializer
    {
        void InitializeData(TestCaseDataContext dbContext);

        void InitializeModel(DbModelBuilder modelBuilder);
    }
}
