using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneList.Controllers;
using PhoneList.Data;
using PhoneList.Dtos;
using PhoneList.Models;
using PhoneList.Profiles;
using Xunit;


namespace PhoneListTests
{
    public class HomeControllerTest
    {
        HomeController _controller;
        IContactsRepo _repository;
        IMapper _mapper;

        public HomeControllerTest()
        {
            var contactprofile = new ContactProfile();
            _repository = new MockContactsRepo();
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(contactprofile); });
            _mapper = mapperConfiguration.CreateMapper();
            var random = new Random();
            _controller = new HomeController(_repository, _mapper);
            
        }

        [Fact]
        public void GetAllContacts__WhenCalled_ReturnOKResult()
        {
            //Act
            var okResult = _controller.GetAllContacts();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetAllContacts__WhenCalled_ReturnAllContacts()
        {
            //Act
            var okResult = _controller.GetAllContacts().Result as OkObjectResult;

            //Assert
            var contacts = Assert.IsType<List<ContactReadDto>>(okResult.Value);
            Assert.Equal(3, contacts.Count);
            Assert.Equal("92068960", contacts[0].PhoneNumber);

        }
        [Fact]
        public void GetContactById__WhenCalled_ReturnCorrectContactAndCheckNumber()
        {
            //Act
            var okResult = _controller.GetContactById(1).Result as OkObjectResult;

            //Assert
            var contact = Assert.IsType<ContactReadDto>(okResult.Value);
            Assert.Equal("92068960", contact.PhoneNumber);
        }

        [Fact]
        public void GetContactById__WhenCalled_ReturnNotFoundForInvalidId()
        {
            //Act
            var okResult = _controller.GetContactById(54);

            //Assert
            Assert.IsType<NotFoundResult>(okResult.Result);

        }

        [Fact]
        public void CreateContact__WhenCalled_VerifyThatCreatedAtRouteResultIsReturned()
        {
            var contact = new ContactCreateDto(){Age="28", Name="Jensemann", PhoneNumber="06000"};
            //Act
            var okResult = _controller.CreateContact(contact);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(okResult.Result);
        }
        [Fact]
        public void CreateContact__WhenCalled_VerifyThatContactIsCreated()
        {
            var contact = new ContactCreateDto() { Age = "28", Name = "Jensemann", PhoneNumber = "06000" };
            //Act
            var okResult = _controller.CreateContact(contact).Result as CreatedAtRouteResult;
            var returnContact = (ContactReadDto)okResult.Value;

            //Assert
            Assert.Equal("Jensemann", returnContact.Name);
        }

    }
}
