using _81MY_SignalROrderMan.DtoLayer.AboutDtos;
using _81MY_SignalROrderMan.DtoLayer.BasketDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;

namespace _81MY_SignalROrderManAPI.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, ResultBasketDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName)).ReverseMap();           
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, CreateBasketWithProductIdDto>().ReverseMap();
            CreateMap<Basket, UpdateBasketDto>().ReverseMap();
            CreateMap<Basket, GetBasketDto>().ReverseMap();
        }
    }
}
