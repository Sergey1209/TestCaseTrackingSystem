using System.Data.Entity;

namespace DataAccess.Initializers
{
    internal interface IEntityInitializer
    {
        void InitializeData(TCTSDataContext dbContext);

        void InitializeModel(DbModelBuilder modelBuilder);
    }
}
