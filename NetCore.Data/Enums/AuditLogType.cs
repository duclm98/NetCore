using System.ComponentModel.DataAnnotations;

namespace NetCore.Data.Enums
{
    public enum AuditLogType
    {
        [Display(Name = "Xem")] Get = 1,
        [Display(Name = "Thêm")] Create,
        [Display(Name = "Sửa")] Update,
        [Display(Name = "Xóa")] Delete,
        [Display(Name = "Khác")] Other
    }
}