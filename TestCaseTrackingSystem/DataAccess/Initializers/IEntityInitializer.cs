using System.Data.Entity;

namespace DataAccess.Initializers
{
    internal interface IEntityInitializer
    {
        void Initialize(TestCaseDataContext dbContext);
    }
}
