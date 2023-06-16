using Api.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.WhenRequestUpdate
{
    //public class Return_Delete
    //{
    //    private UsersController? _controller;
    //    [Fact(DisplayName = "É possivel Realizar o Created")]
    //    public async Task E_Possive_Invocar_a_Controller_Updated()
    //    {
    //        var serviceMock = new Mock<IUserServices>();
    //        var id = Guid.NewGuid();
    //        var nome = Faker.Name.FullName();
    //        var email = Faker.Internet.Email();

    //        serviceMock.Setup(m => m.Put(It.IsAny<UserUpdateDto>())).ReturnsAsync(new UserUpdateResultDto
    //        {
    //            Id = id,
    //            Name = nome,
    //            Email = email,
    //            UpdateAt = DateTime.UtcNow
    //        });

    //        _controller = new UsersController(serviceMock.Object);

    //        var userDtoUpdated = new UserUpdateDto()
    //        {
    //            Id = id,
    //            Name = nome,
    //            Email = email,
    //        };

    //        var result = await _controller.Put(userDtoUpdated);
    //        Assert.NotNull(result);
    //        Assert.True(result is OkObjectResult);
    //        var resultValue = ((OkObjectResult)result).Value as UserUpdateResultDto;
    //        Assert.NotNull(resultValue);
    //        Assert.Equal(userDtoUpdated.Id, resultValue?.Id);
    //        Assert.Equal(userDtoUpdated.Name, resultValue?.Name);
    //        Assert.Equal(userDtoUpdated.Email, resultValue?.Email);
    //    }
    //}
}
