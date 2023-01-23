using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetDevChallange.Core.Entities;

namespace NetDevChallange.DataAccess.Concrete.EntityFramework.Mappings
{
    public abstract class BaseMap<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(c => c.CreatedBy).HasMaxLength(50);
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(c => c.UpdatedBy).HasMaxLength(50);
            builder.Property(c => c.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(c => c.UpdatedOn).HasColumnName("UpdatedOn");
        }

        public abstract void ConfigureMap(EntityTypeBuilder<TBase> builder);
    }
}
