using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class BacklogItemTypesInitializer : IEntityInitializer
    {
        private static readonly IEnumerable<BacklogItemType> BuiltInTypes = new[]
        {
            new BacklogItemType
            {
                ID = 1,
                Type = "Bug"
            },
            new BacklogItemType
            {
                ID = 2,
                Type = "Story"
            }
        };

        public void Initialize(TestCaseDataContext dbContext)
        {
            dbContext.BacklogItemTypes.AddRange(BuiltInTypes);

            dbContext.SaveChanges();
        }
    }
}
