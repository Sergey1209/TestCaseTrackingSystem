using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class UserRolesInitializer : EntityInitializerBase<UserRole>
    {
        protected override IEnumerable<UserRole> BuiltInEntities => new[]
        {
            new UserRole
            {
                ID = 1,
                Role = "Admin"
            },
            new UserRole
            {
                ID = 2,
                Role = "Developer"
            },
            new UserRole
            {
                ID = 3,
                Role = "QA"
            }
        };
    }
}
