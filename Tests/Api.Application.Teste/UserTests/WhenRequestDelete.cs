using Api.Application.Controllers;
using Application.Interfaces;
using Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.UserTest
{
    public class WhenRequestDelete
    {
        [Fact(DisplayName = "Delete User - No Content")]
        public async Task Delete_ReturnNoContent()
        {
            // Arrange
            var Id = Faker.RandomNumber.Next(1, 10);
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.Delete(Id)).ReturnsAsync(Result.Success());

            //Act
            IResult result = await UsersController.DeleteUser(mockUserServices.Object, Id);

            Assert.IsType<NoContent>(result);
        }

        [Fact(DisplayName = "Delete User - Bad Request")]
        public async Task Delete_ReturnBadRequest()
        {
            // Arrange
            var Id = Faker.RandomNumber.Next(1, 10);
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.Delete(Id)).ReturnsAsync(Result.Failure(new Error("User", "Usuario não encontrato")));

            //Act
            IResult result = await UsersController.DeleteUser(mockUserServices.Object, Id);

            // Assert
            Assert.IsType<BadRequest<Result>>(result);
            var badRequestResult = Assert.IsType<BadRequest<Result>>(result).Value;
            Assert.False(badRequestResult!.IsSuccess);
            Assert.NotNull(badRequestResult!.Errors);
            Assert.IsType<Error[]>(badRequestResult!.Errors);
        }
    }
}