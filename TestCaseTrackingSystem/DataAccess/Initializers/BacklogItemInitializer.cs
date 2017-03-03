using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class BacklogItemInitializer : EntityInitializerBase<BacklogItem>
    {
        public override void InitializeModel(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<BacklogItem>();

            entity.HasKey(t => t.ID).Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entity.Property(t => t.Type).IsRequired();
            entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
            entity.Property(t => t.Description).IsOptional();
            entity.Property(t => t.IterationID).IsOptional();
            entity.Property(t => t.CreatedByID).IsRequired();
            entity.Property(t => t.AssignedToID).IsOptional();
        }
    }
}
