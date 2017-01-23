using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Initializers
{
    public abstract class EntityInitializerBase<T> : IEntityInitializer where T : class
    {
        protected abstract IEnumerable<T> BuiltInEntities { get; }
        
        public void InitializeData(TestCaseDataContext dbContext)
        {
            if (BuiltInEntities == null || !BuiltInEntities.Any()) return;

            dbContext.Set<T>().AddRange(BuiltInEntities);
            dbContext.SaveChanges();
        }
    }
}
