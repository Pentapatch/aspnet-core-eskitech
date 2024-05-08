using AutoMapper;
using Eskitech.Contracts.Products;
using Eskitech.Entities.Products;

namespace Eskitech.API.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductGetDto>();
            CreateMap<Product, ProductsGetDto>();
        }
    }
}