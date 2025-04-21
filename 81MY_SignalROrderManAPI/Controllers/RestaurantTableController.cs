using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.OrderDtos;
using _81MY_SignalROrderMan.DtoLayer.RestaurantTableDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IRestaurantTableService _restaurantTableService;
        private readonly IMapper _mapper;

        public RestaurantTableController(IRestaurantTableService restaurantTableService, IMapper mapper)
        {
            _restaurantTableService = restaurantTableService;
            _mapper = mapper;
        }

        [HttpGet("ListRestaurantTable")]
        public IActionResult ListRestaurantTable()
        {
            var values = _mapper.Map<List<ResultRestaurantTableDto>>(_restaurantTableService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateRestaurantTable")]
        public IActionResult CreateRestaurantTable(CreateRestaurantTableDto createRestaurantTableDto)
        {
            var value = _mapper.Map<RestaurantTable>(createRestaurantTableDto);
            _restaurantTableService.TAdd(value);
            return Ok("Masa eklendi!");
        }

        [HttpDelete("DeleteRestaurantTable/{id}")]
        public IActionResult DeleteRestaurantTable(int id)
        {
            var value = _restaurantTableService.TGetById(id);
            _restaurantTableService.TDelete(value);
            return Ok("Masa silindi!");
        }

        [HttpPut("UpdateRestaurantTable/{id}")]
        public IActionResult UpdateRestaurantTable(int id, UpdateRestaurantTableDto updateRestaurantTableDto)
        {
            var value = _restaurantTableService.TGetById(id);
            _mapper.Map(updateRestaurantTableDto, value);
            _restaurantTableService.TUpdate(value);
            return Ok("Masa güncellendi!");
        }

        [HttpGet("GetRestaurantTable/{id}")]
        public IActionResult GetRestaurantTable(int id)
        {
            var value = _restaurantTableService.TGetById(id);
            var restaurantTable = _mapper.Map<GetRestaurantTableDto>(value);
            return Ok(restaurantTable);
        }

        [HttpGet("GetRestaurantTableCount")]
        public IActionResult GetRestaurantTableCount()
        {
            return Ok(_restaurantTableService.TGetRestaurantTableCount());
        }

        [HttpPut("ChangeRestaurantTableStatusToTrue/{id}")]
        public IActionResult ChangeRestaurantTableStatusToTrue(int id)
        {
            _restaurantTableService.TChangeRestaurantTableStatusToTrue(id);
            return Ok("Masa doldu!");
        }

        [HttpPut("ChangeRestaurantTableStatusToFalse/{id}")]
        public IActionResult ChangeRestaurantTableStatusToFalse(int id)
        {
            _restaurantTableService.TChangeRestaurantTableStatusToFalse(id);
            return Ok("Masa boş!");
        }
    }
}
