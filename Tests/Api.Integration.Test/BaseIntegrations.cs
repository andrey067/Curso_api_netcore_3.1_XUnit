using Application.Dtos.Login;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        private bool disposed = false;
        private readonly TestServer server;
        private readonly EnderecosContext context;
        public readonly HttpClient client;
        public string hostApi;
        public HttpResponseMessage response { get; set; }

        public BaseIntegrations()
        {
            hostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Program>();

            server = new TestServer(builder);

            context = server.Host.Services.GetRequiredService<EnderecosContext>();
            context.Database.Migrate();

            client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto("audrey@gmail.com");

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


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    client.Dispose();
                    server.Dispose();
                    context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
