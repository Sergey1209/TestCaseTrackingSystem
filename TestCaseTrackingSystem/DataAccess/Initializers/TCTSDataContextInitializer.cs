using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace DataAccess.Initializers
{
    internal class TCTSDataContextInitializer : CreateDatabaseIfNotExists<TCTSDataContext>
    {
        private static readonly List<IEntityInitializer> EntityInitializers = new List<IEntityInitializer>();

        static TCTSDataContextInitializer()
        {
            Assembly currentAssembly = Assembly.GetAssembly(typeof(TCTSDataContextInitializer));

            var entities = currentAssembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(InitializerAttribute)));

            foreach (var entity in entities)
            {
                var attribute = entity.GetCustomAttributes(typeof(InitializerAttribute)).First() as InitializerAttribute;
                if (attribute == null) continue;

                EntityInitializers.Add((IEntityInitializer)Activator.CreateInstance(attribute.Type));
            }
        }

        private TCTSDataContextInitializer() { }

        protected override void Seed(TCTSDataContext context)
        {
            base.Seed(context);

            EntityInitializers.ForEach(t => t.InitializeData(context));
        }

        public void InitializeModels(DbModelBuilder modelBuilder)
        {
            EntityInitializers.ForEach(t => t.InitializeModel(modelBuilder));
        }
        
        public static TCTSDataContextInitializer Instance = new TCTSDataContextInitializer();

        internal IEntityInitializer this[Type type]
        {
            get { return EntityInitializers.First(t => t.GetType() == type); }
        }
    }
}
