namespace NetCore.Data.Models
{
    public class AuditLogCreateDto
    {
        public int UserId { get; set; }
        public string Method { get; set; }
        public string Creator { get; set; }
    }
}