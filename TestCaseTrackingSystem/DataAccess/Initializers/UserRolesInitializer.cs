using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

        public override void InitializeModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(t => t.ID).Property(t => t.ID).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<UserRole>().Property(t => t.Role).IsRequired().HasMaxLength(20);
        }
    }
}
