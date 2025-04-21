using _81MY_SignalROrderMan.DtoLayer.ContactDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;

namespace _81MY_SignalROrderManAPI.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
    }
}
