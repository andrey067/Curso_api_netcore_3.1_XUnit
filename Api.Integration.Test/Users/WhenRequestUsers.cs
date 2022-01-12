using Domain.Dtos.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Users
{
    public class WhenRequestUsers : BaseIntegrations
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact(DisplayName = "É possivel realizar Crud_Post")]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();
            _name = Faker.Name.FullName();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email
            };


            //Post
            var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            UserDtoCreateResult registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.NotNull(registroPost);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.True(registroPost.Id != default(Guid));
            Assert.Equal(_name, registroPost.Name);

            //GetAll
            response = await client.GetAsync($"{hostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(listJson);
            Assert.True(listJson.Count() > 0);
            Assert.Contains(listJson, c => c.Id == registroPost.Id);


            //Put
            var updateuserDto = new UserDtoUpdate()
            {
                Id = registroPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateuserDto), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            Assert.NotNull(jsonResult);
            var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Name, registroAtualizado.Name);
            Assert.NotEqual(registroPost.Email, registroAtualizado.Email);

            //GetById
            response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionar = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            Assert.Equal(registroSelecionar.Id, registroAtualizado.Id);
            Assert.Equal(registroSelecionar.Name, registroAtualizado.Name);

            //Delete
            response = await client.DeleteAsync($"{hostApi}users/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Get ID depois do delete
            response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);


        }

    }
}
