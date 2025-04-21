using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.ContactDtos;
using _81MY_SignalROrderMan.DtoLayer.DiscountDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/Discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet("ListDiscount")]
        public IActionResult ListDiscount()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateDiscount")]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);

            return Ok("İndirim bilgisi eklendi!");
        }

        [HttpDelete("DeleteDiscount/{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim bilgisi silindi!");
        }

        [HttpPut("UpdateDiscount/{id}")]
        public IActionResult UpdateDiscount(int id, UpdateDiscountDto updateDiscountDto)
        {
            var value = _discountService.TGetById(id);
            _mapper.Map(updateDiscountDto, value);
            _discountService.TUpdate(value);
            return Ok("İndirim bilgisi güncellendi!");
        }

        [HttpGet("GetDiscount/{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            var discount = _mapper.Map<GetDiscountDto>(value);
            return Ok(discount);
        }
    }
}
