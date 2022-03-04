using System;

namespace NetCore.API.Dto
{
    public class BaseDto
    {
        public int? CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}