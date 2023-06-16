using Api.Application.Controllers;
using Api.Domain.Entities;
using Application.Interfaces;
using Domain.Dtos.User;
using Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.UserTest
{
    public class WhenRequestGetById
    {
        [Fact(DisplayName = "Get By Id User - Ok")]
        public async Task GetById_ReturnUser()
        {
            // Arrange
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.Get(It.IsAny<long>())).ReturnsAsync(
                Result<UserDto>.Success(new UserDto
                {
                    Id = null,
                    Email = "Tests@Tests.gmail.com",
                    Name = "Test",
                    CreateAt = null,
                    UpdateAt = null
                }));

            // Act
            IResult result = await UsersController.GetUserById(mockUserServices.Object, It.IsAny<long>());

            //Assert
            Assert.IsType<Ok<Result<UserDto>>>(result);
            var okResult = Assert.IsType<Ok<Result<UserDto>>>(result).Value;
            Assert.IsAssignableFrom<UserDto>(okResult?.Data);

            Assert.NotNull(result);
            Assert.True(okResult?.IsSuccess);
            Assert.NotNull(okResult?.Data);
        }


        [Fact(DisplayName = "Get By Id User - Not Found")]
        public async Task GetById_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var mockUserServices = new Mock<IUserServices>();
            var error = new Error(typeof(User).Name, "Não encontrado");
            mockUserServices.Setup(services => services.Get(It.IsAny<long>())).ReturnsAsync(
                Result<UserDto>.Failure(error));

            // Act
            var result = await UsersController.GetUserById(mockUserServices.Object, It.IsAny<long>());

            // Assert
            Assert.IsType<NotFound<Result<UserDto>>>(result);
            var notFoundResult = Assert.IsType<NotFound<Result<UserDto>>>(result).Value;

            Assert.NotNull(notFoundResult);
            Assert.False(notFoundResult.IsSuccess);
            Assert.Null(notFoundResult.Data);
            Assert.Equal(error, notFoundResult.Errors.First());
        }
    }
}
