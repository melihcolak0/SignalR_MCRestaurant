using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.MoneyCaseDtos;
using _81MY_SignalROrderMan.DtoLayer.OrderDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMapper _mapper;

        public MoneyCaseController(IMoneyCaseService moneyCaseService, IMapper mapper)
        {
            _moneyCaseService = moneyCaseService;
            _mapper = mapper;
        }

        [HttpGet("ListMoneyCase")]
        public IActionResult ListMoneyCase()
        {
            var values = _mapper.Map<List<ResultMoneyCaseDto>>(_moneyCaseService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateMoneyCase")]
        public IActionResult CreateMoneyCase(CreateMoneyCaseDto createMoneyCaseDto)
        {
            var value = _mapper.Map<MoneyCase>(createMoneyCaseDto);
            _moneyCaseService.TAdd(value);
            return Ok("Kasa tutarı eklendi!");
        }

        [HttpDelete("DeleteMoneyCase/{id}")]
        public IActionResult DeleteMoneyCase(int id)
        {
            var value = _moneyCaseService.TGetById(id);
            _moneyCaseService.TDelete(value);
            return Ok("Kasa tutarı silindi!");
        }

        [HttpPut("UpdateMoneyCase/{id}")]
        public IActionResult UpdateMoneyCase(int id, UpdateMoneyCaseDto updateMoneyCaseDto)
        {
            var value = _moneyCaseService.TGetById(id);
            _mapper.Map(updateMoneyCaseDto, value);
            _moneyCaseService.TUpdate(value);
            return Ok("Kasa tutarı güncellendi!");
        }

        [HttpGet("GetMoneyCase/{id}")]
        public IActionResult GetMoneyCase(int id)
        {
            var value = _moneyCaseService.TGetById(id);
            var moneyCase = _mapper.Map<GetMoneyCaseDto>(value);
            return Ok(moneyCase);
        }

        [HttpGet("GetMoneyCaseTotalAmount")]
        public IActionResult GetMoneyCaseTotalAmount()
        {
            return Ok(_moneyCaseService.TGetMoneyCaseTotalAmount());
        }
    }
}
