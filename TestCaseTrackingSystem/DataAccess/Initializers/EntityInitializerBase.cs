using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Initializers
{
    internal abstract class EntityInitializerBase<T> : IEntityInitializer where T : class
    {
        protected abstract IEnumerable<T> BuiltInEntities { get; }

        private bool _isInitialized;

        public virtual void InitializeData(TestCaseDataContext dbContext)
        {
            if (_isInitialized) return;

            if (BuiltInEntities == null || !BuiltInEntities.Any()) return;

            dbContext.Set<T>().AddRange(BuiltInEntities);
            dbContext.SaveChanges();

            _isInitialized = true;
        }

        public abstract void InitializeModel(DbModelBuilder modelBuilder);
    }
}
