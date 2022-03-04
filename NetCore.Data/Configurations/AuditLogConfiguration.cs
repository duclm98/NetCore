using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Data.Entities;

namespace NetCore.Data.Configurations
{
    class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("AuditLogs");
            builder.HasKey(x => x.AuditLogId);
            builder.Property(x => x.AuditLogId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.TableName).IsRequired();
            builder.Property(x => x.PrimaryKey).IsRequired();
            builder.Property(x => x.ColumnName).IsRequired(false);
            builder.Property(x => x.OldValues).IsRequired(false);
            builder.Property(x => x.NewValues).IsRequired(false);
            builder.Property(x => x.UserId).IsRequired(false);

            builder.HasOne(x => x.User)
                .WithMany(y => y.AuditLogs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}