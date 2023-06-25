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
    public class WhenRequestUpdate
    {
        [Fact(DisplayName = "Update User - Ok")]
        public async Task Put_ReturnUpdateUser()
        {
            // Arrange
            var updateUserDto = new UpdateUserDto(Faker.RandomNumber.Next(1, 1000), Faker.Name.FullName(), Faker.Internet.Email());
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.Put(It.IsAny<UpdateUserDto>())).ReturnsAsync(Result<UserDto>.Success(new UserDto()
            {
                Id = updateUserDto.Id,
                Name = updateUserDto.Name,
                Email = updateUserDto.Email,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            }));

            IResult result = await UsersController.UpdateUser(mockUserServices.Object, updateUserDto);

            Assert.IsType<Ok<Result<UserDto>>>(result);
            var createdResult = Assert.IsType<Ok<Result<UserDto>>>(result);
            var returnValue = Assert.IsType<Result<UserDto>>(createdResult.Value);
            var userDto = Assert.IsType<UserDto>(returnValue.Data);

            Assert.Equal(updateUserDto.Id, userDto.Id);
            Assert.Equal(updateUserDto.Name, userDto.Name);
            Assert.Equal(updateUserDto.Email, userDto.Email);
            Assert.Equal(updateUserDto.Id, userDto.Id);
        }

        [Fact(DisplayName = "Update User - BadRequest")]
        public async Task Put_ReturnBadRequest()
        {
            // Arrange
            var updateUserDto = new UpdateUserDto(Faker.RandomNumber.Next(1, 1000), Faker.Name.FullName(), Faker.Internet.Email());
            var mockUserServices = new Mock<IUserServices>();
            mockUserServices.Setup(services => services.Put(It.IsAny<UpdateUserDto>())).ReturnsAsync(Result<UserDto>.Failure(new Error("User", "Erro ao persistir usuario")));

            //Act
            IResult result = await UsersController.UpdateUser(mockUserServices.Object, updateUserDto);

            // Assert
            Assert.IsType<BadRequest<Result<UserDto>>>(result);
            var badRequestResult = Assert.IsType<BadRequest<Result<UserDto>>>(result).Value;
            Assert.False(badRequestResult!.IsSuccess);
            Assert.Null(badRequestResult!.Data);
            Assert.IsType<Error[]>(badRequestResult!.Errors);
        }
    }
}
