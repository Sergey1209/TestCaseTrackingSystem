using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class IterationInitializer: EntityInitializerBase<Iteration>
    {
        public override void InitializeModel(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Iteration>();

            entity.HasKey(t => t.ID).Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entity.Property(t => t.Name).IsRequired().HasMaxLength(200);
            entity.Property(t => t.StartDate).IsRequired();
            entity.Property(t => t.EndDate).IsRequired();
        }
    }
}
