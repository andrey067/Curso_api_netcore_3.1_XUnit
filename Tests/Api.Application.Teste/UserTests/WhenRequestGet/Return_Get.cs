namespace Api.Application.Test.User.WhenRequestGet
{
    //public class Return_Get
    //{
    //    private UsersController? _controller;
    //    [Fact(DisplayName = "É possivel Realizar o Deleted")]
    //    public async Task E_Possive_Invocar_a_Controller_Get()
    //    {
    //        var serviceMock = new Mock<IUserServices>();
    //        var id = Guid.NewGuid();
    //        var nome = Faker.Name.FullName();
    //        var email = Faker.Internet.Email();

    //        serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(new UserDto
    //        {
    //            Id = id,
    //            Name = nome,
    //            Email = email,
    //            CreateAt = DateTime.UtcNow
    //        });


    //        _controller = new UsersController(serviceMock.Object);

    //        var result = await _controller.GetById(id);
    //        Assert.NotNull(result);
    //        Assert.True(result is OkObjectResult);
    //        UserDto resultValue = ((OkObjectResult)result).Value as UserDto;
    //        Assert.NotNull(resultValue);
    //        Assert.Equal(id, resultValue.Id);
    //        Assert.Equal(nome, resultValue.Name);
    //        Assert.Equal(email, resultValue.Email);
    //    }
    //}
}
