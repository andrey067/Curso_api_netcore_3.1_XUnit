using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddTransient<IUserServices, UserService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUfService, UfService>();
            services.AddTransient<IMunicipioService, MunicipioService>();
            services.AddTransient<ICepService, CepService>();            

            return services;
        }
    }
}
