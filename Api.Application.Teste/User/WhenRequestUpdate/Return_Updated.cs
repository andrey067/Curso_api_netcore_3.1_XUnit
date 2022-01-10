using Api.Application.Controllers;
using Api.Domain.Interfaces.Services;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.WhenRequestUpdate
{
    public class Return_Delete
    {
        private UsersController? _controller;
        [Fact(DisplayName = "É possivel Realizar o Created")]
        public async Task E_Possive_Invocar_a_Controller_Updated()
        {
            var serviceMock = new Mock<IUserServices>();
            var id = Guid.NewGuid();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(new UserDtoUpdateResult
            {
                Id = id,
                Name = nome,
                Email = email,
                UpdateAt = DateTime.UtcNow
            });

            _controller = new UsersController(serviceMock.Object);

            var userDtoUpdated = new UserDtoUpdate()
            {
                Id = id,
                Name = nome,
                Email = email,
            };

            var result = await _controller.Put(userDtoUpdated);
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdated.Id, resultValue?.Id);
            Assert.Equal(userDtoUpdated.Name, resultValue?.Name);
            Assert.Equal(userDtoUpdated.Email, resultValue?.Email);
        }
    }
}
