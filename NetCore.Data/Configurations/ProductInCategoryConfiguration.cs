using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Data.Entities;

namespace NetCore.Data.Configurations;

class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
{
    public void Configure(EntityTypeBuilder<ProductInCategory> builder)
    {
        builder.ToTable("ProductInCategories");
        builder.HasKey(x => x.ProductInCategoryId);
        builder.Property(x => x.ProductInCategoryId).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany(y => y.ProductInCategories)
            .HasForeignKey(y => y.ProductId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder.HasOne(x => x.Category)
            .WithMany(y => y.ProductInCategories)
            .HasForeignKey(y => y.CategoryId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}