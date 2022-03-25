using NetCore.Data.Models;
using System;

namespace NetCore.API.Dto
{
    public class BaseDto
    {
        public int? CreatorId { get; set; }
        public string CreatorName { get; set; }
        public EnumValue CreatorRoleObj { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}