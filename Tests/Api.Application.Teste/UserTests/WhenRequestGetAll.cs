using Api.Application.Controllers;
using Application.Interfaces;
using Domain.Dtos.User;
using Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.UserTest
{
    public class WhenRequestGetAll
    {
        [Fact(DisplayName = " Get All Users - Ok")]
        public async Task GetAllUsers_ReturnListOfUsers()
        {
            // Arrange
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.GetAll()).ReturnsAsync(
                Result<IEnumerable<UserDto>>.Success(new List<UserDto>() { new UserDto {
                 Id = null,
                 Email ="Tests@Tests.gmail.com",
                 Name = "Test",
                 CreateAt = null,
                 UpdateAt = null
            } }));

            // Act
            IResult result = await UsersController.GetAllUsers(mockUserServices.Object);

            //Assert
            Assert.IsType<Ok<Result<IEnumerable<UserDto>>>>(result);
            var okResult = Assert.IsType<Ok<Result<IEnumerable<UserDto>>>>(result).Value;
            Assert.IsAssignableFrom<IEnumerable<UserDto>>(okResult?.Data);

            Assert.NotNull(result);
            Assert.True(okResult?.IsSuccess);
            Assert.True(okResult?.Data?.Count() > 0);
        }


        [Fact(DisplayName = "Get All Users - BadRequest")]
        public async Task GetAllUsers_ReturnsBadRequest()
        {
            // Arrange
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.GetAll()).ReturnsAsync(Result<IEnumerable<UserDto>>.Failure(new Error("User", "erro na solicitação")));

            //Act
            IResult result = await UsersController.GetAllUsers(mockUserServices.Object);

            // Assert
            Assert.IsType<BadRequest<Result<IEnumerable<UserDto>>>>(result);
            var badRequestResult = Assert.IsType<BadRequest<Result<IEnumerable<UserDto>>>>(result);
            var failureResult = Assert.IsType<Result<IEnumerable<UserDto>>>(badRequestResult.Value);
            Assert.False(failureResult.IsSuccess);
            Assert.Null(failureResult.Data);
        }

        [Fact(DisplayName = "Get All Users - NotFound")]
        public async Task GetAllUsers_ReturnsNotFound()
        {
            // Arrange
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.GetAll()).ReturnsAsync(
            Result<IEnumerable<UserDto>>.Success());
            // Act
            IResult result = await UsersController.GetAllUsers(mockUserServices.Object);

            // Assert
            Assert.IsType<NotFound<Result<IEnumerable<UserDto>>>>(result);
            var notFoundResult = Assert.IsType<NotFound<Result<IEnumerable<UserDto>>>>(result);
            var failureResult = Assert.IsType<Result<IEnumerable<UserDto>>>(notFoundResult.Value);
            Assert.True(failureResult.IsSuccess);
            Assert.Null(failureResult.Data);
        }
    }
}
