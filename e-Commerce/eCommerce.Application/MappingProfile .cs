using AutoMapper;
using eCommerce.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
         CreateMap<ApplicationUser, UserDto>().ReverseMap();
    }
}
