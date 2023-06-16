using Application.Dtos.Users;
using Domain.Dtos.User;
using Domain.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Users
{
    //public class WhenRequestUsers : BaseIntegrations
    //{
    //    private string _name { get; set; }
    //    private string _email { get; set; }

    //    [Fact(DisplayName = "É possivel realizar Crud_Post")]
    //    public async Task E_Possivel_Realizar_Crud_Usuario()
    //    {
    //        await AdicionarToken();
    //        _name = Faker.Name.FullName();
    //        _email = Faker.Internet.Email();

    //        var userDto = new CreateUserDto(_name, _email);

    //        //Post
    //        var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
    //        var postResult = await response.Content.ReadAsStringAsync();
    //        var registroPost = JsonConvert.DeserializeObject<Result<UserDto>>(postResult);
    //        Assert.NotNull(registroPost);
    //        Assert.True(registroPost.IsSuccess);
    //        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    //        Assert.IsType<long>(registroPost.Data.Id);
    //        Assert.Equal(_name, registroPost.Data.Name);

    //        //GetAll
    //        response = await client.GetAsync($"{hostApi}users");
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //        var jsonResult = await response.Content.ReadAsStringAsync();
    //        var listJson = JsonConvert.DeserializeObject<Result<IEnumerable<UserDto>>>(jsonResult);
    //        Assert.NotNull(listJson);
    //        Assert.True(listJson.Data.Count() > 0);
    //        Assert.Contains(listJson.Data, c => c.Id == registroPost.Data.Id);


    //        //Put
    //        var updateuserDto = new UpdateUserDto(registroPost.Data.Id, Faker.Name.FullName(), Faker.Internet.Email());

    //        var stringContent = new StringContent(JsonConvert.SerializeObject(updateuserDto), Encoding.UTF8, "application/json");
    //        response = await client.PutAsync($"{hostApi}users", stringContent);
    //        jsonResult = await response.Content.ReadAsStringAsync();
    //        Assert.NotNull(jsonResult);
    //        var registroAtualizado = JsonConvert.DeserializeObject<Result<UserDto>>(jsonResult);
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //        Assert.NotEqual(registroPost.Data.Name, registroAtualizado.Data.Name);
    //        Assert.NotEqual(registroPost.Data.Email, registroAtualizado.Data.Email);

    //        //GetById
    //        response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Data.Id}");
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //        jsonResult = await response.Content.ReadAsStringAsync();
    //        var registroSelecionar = JsonConvert.DeserializeObject<UserDto>(jsonResult);
    //        Assert.Equal(registroSelecionar.Id, registroAtualizado.Data.Id);
    //        Assert.Equal(registroSelecionar.Name, registroAtualizado.Data.Name);

    //        //Delete
    //        response = await client.DeleteAsync($"{hostApi}users/{registroAtualizado.Data.Id}");
    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //        //Get ID depois do delete
    //        response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Data.Id}");
    //        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    //    }

    //}
}
