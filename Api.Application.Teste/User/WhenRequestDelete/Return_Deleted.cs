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
    public class Return_Deleted
    {
        private UsersController? _controller;
        [Fact(DisplayName = "É possivel Realizar o Deleted")]
        public async Task E_Possive_Invocar_a_Controller_Deleted()
        {
            var serviceMock = new Mock<IUserServices>();
            var id = Guid.NewGuid();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(id);
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);

            Object resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}
