using NetCore.Data.Enums;

namespace NetCore.Data.Entities
{
    public class AuditLog : Base
    {
        public int AuditLogId { get; set; }
        public int UserId { get; set; }
        public AuditLogType Type { get; set; } = AuditLogType.Other;
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public string ColumnName { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}