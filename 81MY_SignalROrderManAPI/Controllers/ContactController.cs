using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.CategoryDtos;
using _81MY_SignalROrderMan.DtoLayer.ContactDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/Contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("ListContact")]
        public IActionResult ListContact()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateContact")]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);

            return Ok("İletişim bilgisi eklendi!");
        }

        [HttpDelete("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim bilgisi silindi!");
        }

        [HttpPut("UpdateContact/{id}")]
        public IActionResult UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var value = _contactService.TGetById(id);
            _mapper.Map(updateContactDto, value);
            _contactService.TUpdate(value);
            return Ok("İletişim bilgisi güncellendi!");
        }

        [HttpGet("GetContact/{id}")]
        public IActionResult GetContact(int id)
        {            
            var value = _contactService.TGetById(id);
            var contact = _mapper.Map<GetContactDto>(value);
            return Ok(contact);
        }
    }
}
