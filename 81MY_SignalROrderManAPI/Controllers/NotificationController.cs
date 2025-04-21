using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.NotificationDtos;
using _81MY_SignalROrderMan.DtoLayer.OrderDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet("ListNotification")]
        public IActionResult ListNotification()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateNotification")]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var value = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Bildirim eklendi!");
        }

        [HttpDelete("DeleteNotification/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim silindi!");
        }

        [HttpPut("UpdateNotification/{id}")]
        public IActionResult UpdateNotification(int id, UpdateNotificationDto updateNotificationDto)
        {
            var value = _notificationService.TGetById(id);
            _mapper.Map(updateNotificationDto, value);
            _notificationService.TUpdate(value);
            return Ok("Bildirim güncellendi!");
        }

        [HttpGet("GetNotification/{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            var notification = _mapper.Map<GetNotificationDto>(value);
            return Ok(notification);
        }

        [HttpGet("GetUnReadNotificationCount")]
        public IActionResult GetUnReadNotificationCount()
        {
            return Ok(_notificationService.TGetUnReadNotificationCount());
        }

        [HttpGet("ListUnReadNotification")]
        public IActionResult ListUnReadNotification()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TListUnReadNotifications());
            return Ok(values);
        }

        [HttpPut("ChangeNotificationStatus/{id}")]
        public IActionResult ChangeNotificationStatus(int id)
        {            
            _notificationService.TChangeNotificationStatus(id);
            return Ok("Bildirim durumu güncellendi!");
        }
    }
}
