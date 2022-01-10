using Api.Application.Controllers;
using Api.Domain.Interfaces.Services;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.WhenRequestGetAll
{
    public class Return_GetAll
    {
        private UsersController? _controller;
        [Fact(DisplayName = "É possivel Realizar o GetAll")]
        public async Task E_Possive_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserServices>();
            var id = Guid.NewGuid();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(new List<UserDto>
            {
                new UserDto
                {
                Id = id,
                Name = nome,
                Email = email,
                CreateAt = DateTime.UtcNow
                },
                new UserDto
                {
                Id = id,
                Name = nome,
                Email = email,
                CreateAt = DateTime.UtcNow
                }
            });


            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue?.Count() == 2);           
        }
    }
}
