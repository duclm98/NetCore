using AutoMapper;
using NetCore.API.Dto;
using NetCore.Data.Entities;

namespace NetCore.API.MappingProfiles
{
    public class BaseMapping : Profile
    {
        public BaseMapping()
        {
            CreateMap<Base, BaseDto>()
                .ForMember(x => x.Creator, y => y.MapFrom(z => "empty"))
                .ReverseMap();
        }
    }
}