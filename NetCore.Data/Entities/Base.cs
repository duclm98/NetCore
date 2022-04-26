using System;

namespace NetCore.Data.Entities;

public class Base
{
    public int? CreatorId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; }

    public virtual User Creator { get; set; }
}