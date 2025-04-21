using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.OrderDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("ListOrder")]
        public IActionResult ListOrder()
        {
            var values = _mapper.Map<List<ResultOrderDto>>(_orderService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            var value = _mapper.Map<Order>(createOrderDto);
            _orderService.TAdd(value);

            return Ok("Sipariş eklendi!");
        }

        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var value = _orderService.TGetById(id);
            _orderService.TDelete(value);
            return Ok("Sipariş silindi!");
        }

        [HttpPut("UpdateOrder/{id}")]
        public IActionResult UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var value = _orderService.TGetById(id);
            _mapper.Map(updateOrderDto, value);
            _orderService.TUpdate(value);
            return Ok("Sipariş güncellendi!");
        }

        [HttpGet("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            var value = _orderService.TGetById(id);
            var testimonial = _mapper.Map<GetOrderDto>(value);
            return Ok(testimonial);
        }

        [HttpGet("GetTotalOrderCount")]
        public IActionResult GetTotalOrderCount()
        {
            return Ok(_orderService.TGetOrderCount());
        }

        [HttpGet("GetActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            return Ok(_orderService.TGetActiveOrderCount());
        }

        [HttpGet("GetLastOrderPrice")]
        public IActionResult GetLastOrderPrice()
        {
            return Ok(_orderService.TGetLastOrderPrice());
        }

        [HttpGet("GetTodaysTotalPrice")]
        public IActionResult GetTodaysTotalPrice()
        {
            return Ok(_orderService.TGetTodaysTotalPrice());
        }
    }
}
