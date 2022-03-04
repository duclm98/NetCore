using NetCore.Data.Enums;
using System;

namespace NetCore.Data.Entities
{
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
}