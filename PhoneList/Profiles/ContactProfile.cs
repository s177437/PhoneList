using AutoMapper;
using PhoneList.Dtos;
using PhoneList.Models;
using System;
namespace PhoneList.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactReadDto>();
            CreateMap<ContactCreateDto, Contact>();
            CreateMap<ContactUpdateDto, Contact>();
            CreateMap<Contact, ContactUpdateDto>();
        }
    }
}
