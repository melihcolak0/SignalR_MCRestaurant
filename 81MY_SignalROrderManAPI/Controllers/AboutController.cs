using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.AboutDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/About")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("ListAbout")] // Listeleme
        public IActionResult ListAbout()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpPost("CreateAbout")] // Ekleme
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };
            _aboutService.TAdd(about);
            return Ok("Hakkımda bölümü başarıyla eklendi!");
        }

        [HttpDelete("DeleteAbout/{id}")] // Silme
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda bölümü başarıyla silindi!");
        }

        [HttpPut("UpdateAbout")] // Güncelleme
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId = updateAboutDto.AboutId,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda bölümü başarıyla güncellendi");
        }

        [HttpGet("GetAbout/{id}")] // Id'ye Göre Getirme
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
