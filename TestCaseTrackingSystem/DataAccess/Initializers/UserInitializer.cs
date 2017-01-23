using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class UserInitializer : EntityInitializerBase<User>
    {
        protected override IEnumerable<User> BuiltInEntities => new[]
        {
            new User
            {
                ID = 1,
                RoleID = 1,
                Login = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@tcts.by",
                Password = "admin",
                LastLogin = null,
                CreatedDate = DateTime.Now,
                Locked = false
            } 
        };
    }
}
