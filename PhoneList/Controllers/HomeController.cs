using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PhoneList.Data;
using PhoneList.Dtos;
using PhoneList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneList.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IContactsRepo _repository;
        private readonly IMapper _mapper;

        public HomeController(IContactsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/contacts
        [HttpGet]
        public ActionResult<IEnumerable<ContactReadDto>> GetAllContacts()
        {
            var contactItems = _repository.GetAllContacts();
            return Ok(_mapper.Map<IEnumerable<ContactReadDto>>(contactItems));

        }

        // GET /api/contacts/id
        [HttpGet("{id}", Name = "GetContactById")]
        public ActionResult<ContactReadDto> GetContactById(int id)
        {
            var contactItem = _repository.GetContactById(id);
            if (contactItem != null)
            {
                return Ok(_mapper.Map<ContactReadDto>(contactItem));
            }
            return NotFound();
        }

        //POST /api/contacts
        [HttpPost]
        public ActionResult<ContactReadDto> CreateContact(ContactCreateDto contactCreateDto)
        {
            var contactModel = _mapper.Map<Contact>(contactCreateDto);
            _repository.CreateContact(contactModel);
            _repository.SaveChanges();

            var contactReadDto = _mapper.Map<ContactReadDto>(contactModel);
            return CreatedAtRoute(nameof(GetContactById), new { Id = contactReadDto.Id }, contactReadDto);
        }

        //PUT api/contacts/{id}
        [HttpPut("{id}")]
        public ActionResult<ContactUpdateDto> UpdateContact(int id, ContactUpdateDto contactUpdateDto)
        {
            var existingContactFromDb = _repository.GetContactById(id);
            if (existingContactFromDb == null)
            {
                return NotFound();
            }
            _mapper.Map(contactUpdateDto, existingContactFromDb);
            _repository.UpdateContact(existingContactFromDb);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH /api/contact/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialContactUpdate(int id, JsonPatchDocument<ContactUpdateDto> patchDocument)
        {
            var existingContactFromDb = _repository.GetContactById(id);

            if (existingContactFromDb == null)
            {
                return NotFound();
            }

            var contactToPatch = _mapper.Map<ContactUpdateDto>(existingContactFromDb);
            patchDocument.ApplyTo(contactToPatch, ModelState);

            if (!TryValidateModel(contactToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(contactToPatch, existingContactFromDb);
            _repository.UpdateContact(existingContactFromDb);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE /api/contact
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            var contactFromDb = _repository.GetContactById(id);
            if(contactFromDb == null)
            {
                return NotFound();
            }
            _repository.DeleteContact(contactFromDb);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
