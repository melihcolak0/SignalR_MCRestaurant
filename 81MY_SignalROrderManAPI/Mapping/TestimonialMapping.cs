using _81MY_SignalROrderMan.DtoLayer.TestimonialDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;

namespace _81MY_SignalROrderManAPI.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
        }
    }
}
