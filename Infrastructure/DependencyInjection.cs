using Data.Implementations;
using Domain.Repository;
using Domain.Security;
using Infrastructure.Configurations;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            if (environment.IsEnvironment("Testing"))
            {
                Environment.SetEnvironmentVariable("DB_CONNECTION", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CursoApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                Environment.SetEnvironmentVariable("DATABASE", "SQLSERVER");
                Environment.SetEnvironmentVariable("MIGRATION", "APLICAR");
                Environment.SetEnvironmentVariable("Audience", "ExemploAudience");
                Environment.SetEnvironmentVariable("Issuer", "ExemploIssue");
                Environment.SetEnvironmentVariable("Seconds", "28800");
            }


            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "POSTGRES".ToLower())
            {
                services.AddDbContext<EnderecosContext>(
            options => options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }
            else
            {
                //ConectionString MySQL
                //services.AddDbContext<EnderecosContext>(
                //options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }


            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserImplementation>();
            services.AddScoped<IUfRepository, UfImplementation>();
            services.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            services.AddScoped<ICepRepository, CepImplementation>();

            TypeAdapterConfig.GlobalSettings.Scan(assembly);
            SwaggerConfiguration.ConfigureServices(services);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);


            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = Environment.GetEnvironmentVariable("Audience");
                paramsValidation.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });
            return services;
        }
    }
}
