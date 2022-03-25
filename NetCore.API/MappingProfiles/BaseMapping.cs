using AutoMapper;
using NetCore.API.Dto;
using NetCore.Data.Entities;
using NetCore.Helpers.Extensions;

namespace NetCore.API.MappingProfiles
{
    public class BaseMapping : Profile
    {
        public BaseMapping()
        {
            CreateMap<Base, BaseDto>()
                .ForMember(x => x.CreatorId, y => y.MapFrom(z => z.CreatorId))
                .ForMember(x => x.CreatorName, y => y.MapFrom(z => z.Creator.Username))
                .ForMember(x => x.CreatorRoleObj, y => y.MapFrom(z => z.Creator.Role.GetValue()))
                .ReverseMap();
        }
    }
}