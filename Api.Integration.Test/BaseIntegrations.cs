using Api.Application;
using Api.Data.Context;
using AutoMapper;
using CrossCutting.Mappings;
using Domain.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
    public class BaseIntegrations : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient client { get; private set; }

        public IMapper mapper { get; set; }

        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }

        public BaseIntegrations()
        {
            hostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();
            client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto()
            {
                Email = "audrey@gmail.com"
            };

            var resultLoging = await PostJsonAsync(loginDto, $"{hostApi}login", client);
            var jsonLogin = await resultLoging.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.accessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(dataclass), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });
            return config.CreateMapper();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
