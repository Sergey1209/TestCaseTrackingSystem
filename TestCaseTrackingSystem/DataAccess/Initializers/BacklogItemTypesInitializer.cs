using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class BacklogItemTypesInitializer : EntityInitializerBase<BacklogItemType>
    {
        protected override IEnumerable<BacklogItemType> BuiltInEntities => new[]
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
    }
}
