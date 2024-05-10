using AutoMapper;
using Eskitech.Contracts.Categories;
using Eskitech.Contracts.Lookup;
using Eskitech.Entities.Categories;

namespace Eskitech.API.MappingProfiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, LookupDto<Category>>()
                .ForMember(dto => dto.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dto => dto.DisplayName, options => options.MapFrom(src => src.Name));
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>();
            CreateMap<Category, CategoriesGetDto>();
        }
    }
}