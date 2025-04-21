using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.ProductDtos;
using _81MY_SignalROrderMan.DtoLayer.SocialMediaDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/SocialMedia")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet("ListSocialMedia")]
        public IActionResult ListSocialMedia()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateSocialMedia")]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);

            return Ok("Sosyal Medya hesabı eklendi!");
        }

        [HttpDelete("DeleteSocialMedia/{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya hesabı silindi!");
        }

        [HttpPut("UpdateSocialMedia/{id}")]
        public IActionResult UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _socialMediaService.TGetById(id);
            _mapper.Map(updateSocialMediaDto, value);
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal Medya hesabı güncellendi!");
        }

        [HttpGet("GetSocialMedia/{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            var socialMedia = _mapper.Map<GetSocialMediaDto>(value);
            return Ok(socialMedia);
        }
    }
}
