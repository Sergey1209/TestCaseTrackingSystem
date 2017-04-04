using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Initializers
{
    public abstract class EntityInitializerBase<T> : IEntityInitializer where T : class
    {
        protected virtual IEnumerable<T> BuiltInEntities => null;
        
        public virtual void InitializeData(TCTSDataContext dbContext)
        {
            if (BuiltInEntities == null || !BuiltInEntities.Any()) return;

            dbContext.Set<T>().AddRange(BuiltInEntities);
            dbContext.SaveChanges();
        }

        public abstract void InitializeModel(DbModelBuilder modelBuilder);
    }
}
