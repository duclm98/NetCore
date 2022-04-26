using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Data.Entities;

public class AuditLog
{
    public int AuditLogId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int? UserId { get; set; }
    public AuditLogType Type { get; set; } = AuditLogType.Other;
    public string TableName { get; set; }
    public string PrimaryKey { get; set; }
    public string ColumnName { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }

    public virtual User User { get; set; }
}

public enum AuditLogType
{
    [Display(Name = "Xem")] Get = 1,
    [Display(Name = "Thêm")] Create,
    [Display(Name = "Sửa")] Update,
    [Display(Name = "Xóa")] Delete,
    [Display(Name = "Khác")] Other
}