using Api.Application.Controllers;
using Api.Domain.Interfaces.Services;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.WhenRequestGet
{
    public class Return_BadRequest
    {
        private UsersController? _controller;

        [Fact(DisplayName = "É possivel Realizar o Deleted")]
        public async Task E_Possive_Invocar_a_Controller_Deleted()
        {
            var serviceMock = new Mock<IUserServices>();
            var id = Guid.NewGuid();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(new UserDto
            {
                Id = id,
                Name = nome,
                Email = email,
                CreateAt = DateTime.UtcNow
            });
            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetById(Guid.NewGuid());
            Assert.NotNull(result is BadRequestResult);
        }
    }
}
