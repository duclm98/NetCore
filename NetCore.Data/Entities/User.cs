using NetCore.Data.Enums;

namespace NetCore.Data.Entities
{
    public class User : Base
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public Role Role { get; set; }
    }
}