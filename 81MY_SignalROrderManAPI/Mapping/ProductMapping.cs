using _81MY_SignalROrderMan.DtoLayer.ProductDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;

namespace _81MY_SignalROrderManAPI.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoriesDto>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category != null ? z.Category.CategoryName : "Kategori Yok"))
                .ReverseMap();
        }
    }
}
