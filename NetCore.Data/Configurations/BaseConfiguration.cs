using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Data.Entities;

namespace NetCore.Data.Configurations
{
    public class BaseConfiguration : IEntityTypeConfiguration<Base>
    {
        public void Configure(EntityTypeBuilder<Base> builder)
        {
            builder.Property(x => x.Creator).IsRequired(false);
            builder.Property(x => x.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DeletedAt).HasColumnType("datetime").IsRequired(false);
        }
    }
}