using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class BacklogItemTypeInitializer : EntityInitializerBase<BacklogItemType>
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

        public override void InitializeModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BacklogItemType>().HasKey(t => t.ID).Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<BacklogItemType>().Property(t => t.Type).IsRequired().HasMaxLength(20);
        }
    }
}
