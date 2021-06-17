using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Data.Models;

namespace NetCore.Data.Configurations
{
    class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(x => new { x.CategoryID, x.ProductID });
            builder.HasOne(x => x.Product).WithMany(y => y.ProductInCategories)
                .HasForeignKey(y => y.ProductID);
            builder.HasOne(x => x.Category).WithMany(y => y.ProductInCategories)
                .HasForeignKey(y => y.CategoryID);
        }
    }
}
