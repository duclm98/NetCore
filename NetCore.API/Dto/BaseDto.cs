using System;

namespace NetCore.API.Dto
{
    public class BaseDto
    {
        public string Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}