using System.ComponentModel.DataAnnotations;

namespace NetCore.Data.Enums
{
    public enum UserRole
    {
        [Display(Name = "Quản lý")] Manager = 1,
        [Display(Name = "Nhân viên")] Employee
    }
}