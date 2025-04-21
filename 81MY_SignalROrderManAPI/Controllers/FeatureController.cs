using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.DiscountDtos;
using _81MY_SignalROrderMan.DtoLayer.FeatureDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/Feature")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet("ListFeature")]
        public IActionResult ListFeature()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateFeature")]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(value);

            return Ok("Özellik bilgisi eklendi!");
        }

        [HttpDelete("DeleteFeature/{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Özellik bilgisi silindi!");
        }

        [HttpPut("UpdateFeature/{id}")]
        public IActionResult UpdateFeature(int id, UpdateFeatureDto updateFeatureDto)
        {
            var value = _featureService.TGetById(id);
            _mapper.Map(updateFeatureDto, value);
            _featureService.TUpdate(value);
            return Ok("Özellik bilgisi güncellendi!");
        }

        [HttpGet("GetFeature/{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            var feature = _mapper.Map<GetFeatureDto>(value);
            return Ok(feature);
        }
    }
}
