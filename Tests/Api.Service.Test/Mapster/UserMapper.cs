namespace Api.Service.Test.AutoMapper
{
    //public class UserMapper : BaseTesteService
    //{
    //[Fact(DisplayName = "É possivel Mapear os Modelos")]
    //public void Can_map_UsersModels()
    //{
    //    var model = new UserModel
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = Faker.Name.FullName(),
    //        Email = Faker.Internet.Email(),
    //        CreateAt = DateTime.Now,
    //        UpdateAt = DateTime.Now
    //    };

    //    var listEntity = new List<UserEntity>();
    //    for (int i = 0; i < 10; i++)
    //    {
    //        var item = new UserEntity
    //        {
    //            Id = Guid.NewGuid(),
    //            Name = Faker.Name.FullName(),
    //            Email = Faker.Internet.Email(),
    //            CreateAt = DateTime.Now,
    //            UpdateAt = DateTime.Now,
    //        };
    //        listEntity.Add(item);
    //    }

    //    //Model => User Entity
    //    var dtoToEntity = Mapper.Map<UserEntity>(model);
    //    Assert.Equal(dtoToEntity.Id, model.Id);
    //    Assert.Equal(dtoToEntity.Name, model.Name);
    //    Assert.Equal(dtoToEntity.Email, model.Email);
    //    Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
    //    Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);

    //    //Entity => dto
    //    var userdto = Mapper.Map<UserDto>(dtoToEntity);
    //    Assert.Equal(userdto.Id, dtoToEntity.Id);
    //    Assert.Equal(userdto.Name, dtoToEntity.Name);
    //    Assert.Equal(userdto.Email, dtoToEntity.Email);
    //    Assert.Equal(userdto.CreateAt, dtoToEntity.CreateAt);

    //    var listDto = Mapper.Map<List<UserDto>>(listEntity);
    //    Assert.True(listDto.Count() == listEntity.Count());

    //    for (int i = 0; i < listDto.Count(); i++)
    //    {
    //        Assert.Equal(listDto[i].Id, listEntity[i].Id);
    //        Assert.Equal(listDto[i].Name, listEntity[i].Name);
    //        Assert.Equal(listDto[i].Email, listEntity[i].Email);
    //        Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
    //    }

    //    var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(dtoToEntity);
    //    Assert.Equal(userDtoCreateResult.Id, dtoToEntity.Id);
    //    Assert.Equal(userDtoCreateResult.Name, dtoToEntity.Name);
    //    Assert.Equal(userDtoCreateResult.Email, dtoToEntity.Email);
    //    Assert.Equal(userDtoCreateResult.CreateAt, dtoToEntity.CreateAt);

    //    var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(dtoToEntity);
    //    Assert.Equal(userDtoUpdateResult.Id, dtoToEntity.Id);
    //    Assert.Equal(userDtoUpdateResult.Name, dtoToEntity.Name);
    //    Assert.Equal(userDtoUpdateResult.Email, dtoToEntity.Email);
    //    Assert.Equal(userDtoUpdateResult.UpdateAt, dtoToEntity.UpdateAt);

    //    //Dto para Model
    //    var userModel = Mapper.Map<UserModel>(userdto);
    //    Assert.Equal(userModel.Id, userdto.Id);
    //    Assert.Equal(userModel.Name, userdto.Name);
    //    Assert.Equal(userModel.Email, userdto.Email);
    //    Assert.Equal(userModel.CreateAt, userdto.CreateAt);

    //    var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
    //    Assert.Equal(userDtoCreate.Name, userModel.Name);
    //    Assert.Equal(userDtoCreate.Email, userModel.Email);

    //    var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
    //    Assert.Equal(userDtoUpdate.Id, userModel.Id);
    //    Assert.Equal(userDtoUpdate.Name, userModel.Name);
    //    Assert.Equal(userDtoUpdate.Email, userModel.Email);

    //}
    //}
}
