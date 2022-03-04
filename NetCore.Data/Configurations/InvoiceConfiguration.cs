using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Data.Entities;

namespace NetCore.Data.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(x => x.InvoiceId);
            builder.Property(x => x.InvoiceId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(y => y.Invoices)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(x => x.User)
                .WithMany(y => y.Invoices)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
