using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.MessageDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;

        public MessageController(IMapper mapper, IMessageService messageService)
        {
            _mapper = mapper;
            _messageService = messageService;
        }

        [HttpGet("ListMessage")]
        public IActionResult ListMessage()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateMessage")]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(value);

            return Ok("Mesaj eklendi!");
        }

        [HttpDelete("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj silindi!");
        }

        [HttpPut("UpdateMessage/{id}")]
        public IActionResult UpdateMessage(int id, UpdateMessageDto updateMessageDto)
        {
            var value = _messageService.TGetById(id);
            _mapper.Map(updateMessageDto, value);
            _messageService.TUpdate(value);
            return Ok("Mesaj güncellendi!");
        }

        // 2. Yöntem (Daha kısa ve iyi)
        //[HttpPut("UpdateMessage")]
        //public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        //{
        //    var value = _mapper.Map<Message>(updateMessageDto);
        //    _messageService.TUpdate(value);
        //    return Ok("Mesaj güncellendi!");
        //}

        [HttpGet("GetMessage/{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            var message = _mapper.Map<GetMessageDto>(value);
            return Ok(message);
        }
    }
}
