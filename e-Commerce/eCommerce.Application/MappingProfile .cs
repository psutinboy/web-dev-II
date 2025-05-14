using AutoMapper;
using eCommerce.Domain.Entities;
using eCommerce.Application.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Inventory, InventoryDto>().ReverseMap();
    }
}
