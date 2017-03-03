using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class TestCaseInitializer : EntityInitializerBase<TestCase>
    {
        public override void InitializeModel(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TestCase>();

            entity.HasKey(t => t.ID).Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
            entity.Property(t => t.Description).IsOptional();
            entity.Property(t => t.Status).IsRequired();
            entity.Property(t => t.CreatedByID).IsOptional();
            entity.Property(t => t.DateCreated).IsRequired();
            entity.Property(t => t.RunByID).IsOptional();
            entity.Property(t => t.BacklogItemID).IsRequired();
        }
    }
}
