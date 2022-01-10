using Api.Application.Controllers;
using Api.Domain.Interfaces.Services;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.WhenRequestDelete
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

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato invalido");



            var result = await _controller.Delete(default(Guid));
            Assert.NotNull(result);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
