using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetCore.Data.Entities;
using NetCore.Data.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.Data.Models
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }
        public string Method { get; set; }
        public int? UserId { get; set; }
        public AuditLogType Type { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<string> ChangedColumns { get; } = new List<string>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditLog ToAudit()
        {
            var changedColumnRemoveDuplicate = ChangedColumns.Distinct().ToList();
            return new AuditLog
            {
                UserId = UserId,
                Type = Type,
                TableName = TableName,
                PrimaryKey = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
                ColumnName = changedColumnRemoveDuplicate.Count == 0
                    ? null : JsonConvert.SerializeObject(changedColumnRemoveDuplicate)
            };
        }
    }
}