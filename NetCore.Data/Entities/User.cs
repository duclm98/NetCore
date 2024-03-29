﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Data.Entities;

public class User : Base
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string RefreshToken { get; set; }
    public UserRole Role { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; set; }
    public virtual ICollection<User> CreateItems { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
}

public enum UserRole
{
    [Display(Name = "Quản lý")] Manager = 1,
    [Display(Name = "Nhân viên")] Employee
}