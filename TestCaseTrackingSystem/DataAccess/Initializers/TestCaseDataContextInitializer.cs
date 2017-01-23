using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Initializers
{
    internal class TestCaseDataContextInitializer : CreateDatabaseIfNotExists<TestCaseDataContext>
    {
        private static readonly List<IEntityInitializer> EntityInitializers = new List<IEntityInitializer>
        {
            new BacklogItemTypesInitializer(),
            new UserRolesInitializer(),
            new UserInitializer(),
            new TestCaseStatusInitializer()
        };

        protected override void Seed(TestCaseDataContext context)
        {
            base.Seed(context);

            EntityInitializers.ForEach(t => t.InitializeData(context));
        }
    }
}
