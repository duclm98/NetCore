using AutoMapper;
using NetCore.API.Dto;
using NetCore.API.Dto.Product;
using NetCore.Data.Entities;

namespace NetCore.API.MappingProfiles
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDto>()
                .IncludeBase<Base, BaseDto>()
                .ReverseMap();
        }
    }
}