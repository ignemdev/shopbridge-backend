using AutoMapper;
using ShopBridge.Core.DTOs.Category;
using ShopBridge.Core.DTOs.Product;
using ShopBridge.Core.Entities;

namespace ShopBridge.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryAddDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryDetailDto>().ReverseMap();
        CreateMap<Category, CategoryListDetailDto>().ReverseMap();
        CreateMap<Product, CategoryProductListDetailDto>().ReverseMap();

        CreateMap<Product, ProductAddDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        CreateMap<Product, ProductDetailDto>().ReverseMap();
        CreateMap<Product, ProductListDetailDto>().ReverseMap();
        CreateMap<Product, ProductStockUpdateDto>().ReverseMap();
        CreateMap<Category, ProductCategoryListDetailDto>().ReverseMap();
    }
}
