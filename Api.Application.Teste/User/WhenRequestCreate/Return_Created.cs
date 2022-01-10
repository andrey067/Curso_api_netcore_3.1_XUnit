using Api.Application.Controllers;
using Api.Domain.Interfaces.Services;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.WhenRequestCreate
{
    public class Return_Created
    {
        private UsersController? _controller;

        [Fact(DisplayName = "É possivel Realizar o Created")]
        public async Task E_Possive_Invovar_a_Controller()
        {
            var serviceMock = new Mock<IUserServices>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(new UserDtoCreateResult
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email,
                CreateAt = DateTime.UtcNow
            });

            _controller = new UsersController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate()
            {
                Name = nome,
                Email = email
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoCreate.Name, resultValue?.Name);
            Assert.Equal(userDtoCreate.Email, resultValue?.Email);
        }
    }
}
