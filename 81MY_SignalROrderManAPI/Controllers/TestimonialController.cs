using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.ProductDtos;
using _81MY_SignalROrderMan.DtoLayer.TestimonialDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/Testimonial")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet("ListTestimonial")]
        public IActionResult ListTestimonial()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateTestimonial")]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);

            return Ok("Referans eklendi!");
        }

        [HttpDelete("DeleteTestimonial/{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Referans silindi!");
        }

        [HttpPut("UpdateTestimonial/{id}")]
        public IActionResult UpdateTestimonial(int id, UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _testimonialService.TGetById(id);
            _mapper.Map(updateTestimonialDto, value);
            _testimonialService.TUpdate(value);
            return Ok("Referans güncellendi!");
        }

        [HttpGet("GetTestimonial/{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            var testimonial = _mapper.Map<GetTestimonialDto>(value);
            return Ok(testimonial);
        }
    }
}
