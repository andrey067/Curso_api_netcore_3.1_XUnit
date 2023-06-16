using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Data.Test
{
    public class BaseTests : IDisposable
    {
        private readonly string dataBaseName;
        public readonly ServiceProvider serviceProvider;

        public BaseTests()
        {
            dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<EnderecosContext>(options =>
                options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog={dataBaseName};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"),
                ServiceLifetime.Transient);

            serviceProvider = serviceCollection.BuildServiceProvider();
            using (var context = serviceProvider.GetService<EnderecosContext>())
                context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            using (var context = serviceProvider.GetRequiredService<EnderecosContext>())
                context.Database.EnsureDeleted();

            serviceProvider.Dispose();
        }
    }
}

