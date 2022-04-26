using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Data.Entities;

namespace NetCore.Data.Configurations;

class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductId).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Price).IsRequired();
    }
}