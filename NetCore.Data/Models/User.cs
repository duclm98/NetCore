using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using NetCore.Data.Enums;

namespace NetCore.Data.Models
{
    public class User
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public Role Role { get; set; }
    }
}
