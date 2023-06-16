using Api.Application.Controllers;
using Api.routerslication.Controllers;
using Application;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Presentation.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(Presentation.Configuration.AssemblyReference.Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAplication()
                 .AddInfrastructure(builder.Configuration, builder.Environment)
                 .AddPresentation();


var app = builder.Build();

app.MapGroup("/api/cep").MapCepController().MapSwagger();
app.MapGroup("/api/login").AllowAnonymous().MapLoginController().MapSwagger();
app.MapGroup("/api/municipio").RequireAuthorization("Bearer").MapMunicipiosController().MapSwagger();
app.MapGroup("/api/uf").RequireAuthorization("Bearer").MapUfController().MapSwagger();
app.MapGroup("/api/user").RequireAuthorization("Bearer").MapUsersController().MapSwagger();
app.ConfigureSwagger();


if (Environment.GetEnvironmentVariable("MIGRATION").ToLower() == "APLICAR".ToLower())
{
    using (var service = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    using (var context = service.ServiceProvider.GetService<EnderecosContext>())
    {
        if (context!.Database.GetPendingMigrations().Any())
            await context.Database.MigrateAsync();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

