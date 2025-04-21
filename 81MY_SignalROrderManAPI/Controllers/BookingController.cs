using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.BookingDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IValidator<CreateBookingDto> _validator;
        private readonly IMapper _mapper;


        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("ListBooking")]
        public IActionResult ListBooking()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost("CreateBooking")]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Rezervasyon yapıldı!");
        }

        [HttpDelete("DeleteBooking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon silindi!");
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon güncellendi!");
        }

        [HttpGet("GetBooking/{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }

        [HttpPut("ConfirmStatus/{id}")]
        public IActionResult ConfirmStatus(int id)
        {            
            _bookingService.TConfirmBookingStatus(id);
            return Ok("Rezervasyon onaylandı!");
        }

        [HttpPut("CancelStatus/{id}")]
        public IActionResult CancelStatus(int id)
        {
            _bookingService.TCancelBookingStatus(id);
            return Ok("Rezervasyon iptal edildi!");
        }

        //Eski ekleme yöntemi (Auto Mapper Yok)
        //[HttpPost("CreateBooking")]
        //public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        //{
        //    Booking booking = new Booking()
        //    {
        //        Name = createBookingDto.Name,
        //        Description = createBookingDto.Description,
        //        Phone = createBookingDto.Phone,
        //        Mail = createBookingDto.Mail,
        //        PersonCount = createBookingDto.PersonCount,
        //        BookDate = createBookingDto.BookDate
        //    };

        //    _bookingService.TAdd(booking);
        //    return Ok("Rezervasyon yapıldı!");
        //}

        //Eski güncelleme yöntemi (Auto Mapper Yok)
        //[HttpPut("UpdateBooking")]
        //public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        //{
        //    Booking booking = new Booking()
        //    {
        //        BookingId = updateBookingDto.BookingId,
        //        Name = updateBookingDto.Name,
        //        Description = updateBookingDto.Description,
        //        Phone = updateBookingDto.Phone,
        //        Mail = updateBookingDto.Mail,
        //        PersonCount = updateBookingDto.PersonCount,
        //        BookDate = updateBookingDto.BookDate
        //    };

        //    _bookingService.TUpdate(booking);
        //    return Ok("Rezervasyon güncellendi!");
        //}
    }
}
