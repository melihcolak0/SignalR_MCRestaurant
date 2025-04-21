using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.SliderDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet("ListSlider")]
        public IActionResult ListSlider()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateSlider")]
        public IActionResult CreateTestimonial(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(value);

            return Ok("Slider eklendi!");
        }

        [HttpDelete("DeleteSlider/{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Slider silindi!");
        }

        [HttpPut("UpdateSlider/{id}")]
        public IActionResult UpdateSlider(int id, UpdateSliderDto updateSliderDto)
        {
            var value = _sliderService.TGetById(id);
            _mapper.Map(updateSliderDto, value);
            _sliderService.TUpdate(value);
            return Ok("Slider güncellendi!");
        }

        [HttpGet("GetSlider/{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            var slider = _mapper.Map<GetSliderDto>(value);
            return Ok(slider);
        }
    }
}