using Api.Domain.Interfaces.Services;
using Api.Service.Services;
using Domain.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserServices, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}