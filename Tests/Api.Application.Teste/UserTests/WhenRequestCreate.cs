using Api.Application.Controllers;
using Application.Dtos.Users;
using Application.Interfaces;
using Domain.Dtos.User;
using Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.UserTest
{
    public class WhenRequestCreate
    {
        [Fact(DisplayName = "Create User - Created")]
        public async Task Post_ReturnCreatedUser()
        {
            // Arrange
            var createUserDto = new CreateUserDto(Faker.Name.FullName(), Faker.Internet.Email());
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.Post(createUserDto)).ReturnsAsync(Result<UserDto>.Success(new UserDto()
            {
                Id = 1,
                Name = createUserDto.nome,
                Email = createUserDto.email,
                CreateAt = DateTime.Now
            }));


            IResult result = await UsersController.CreateUser(mockUserServices.Object, createUserDto);

            Assert.IsType<CreatedAtRoute<Result<UserDto>>>(result);
            var createdResult = Assert.IsType<CreatedAtRoute<Result<UserDto>>>(result);
            var returnValue = Assert.IsType<Result<UserDto>>(createdResult.Value);
            var userDto = Assert.IsType<UserDto>(returnValue.Data);

            Assert.Equal(createUserDto.nome, userDto.Name);
            Assert.Equal(createUserDto.email, userDto.Email);
            Assert.Equal(1, userDto.Id);
        }


        [Fact(DisplayName = "Create User - BadRequest")]
        public async Task Post_ReturnBadRequest()
        {
            // Arrange
            var createUserDto = new CreateUserDto(Faker.Name.FullName(), Faker.Internet.Email());
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.Post(createUserDto)).ReturnsAsync(Result<UserDto>.Failure(new Error("User", "Erro ao persistir usuario")));

            //Act
            IResult result = await UsersController.CreateUser(mockUserServices.Object, createUserDto);

            // Assert
            Assert.IsType<BadRequest<Result<UserDto>>>(result);
            var badRequestResult = Assert.IsType<BadRequest<Result<UserDto>>>(result).Value;
            Assert.False(badRequestResult!.IsSuccess);
            Assert.Null(badRequestResult!.Data);
            Assert.IsType<Error[]>(badRequestResult!.Errors);
        }
    }
}
