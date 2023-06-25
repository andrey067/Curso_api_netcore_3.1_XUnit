using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<EnderecosContext>
    {
        public EnderecosContext CreateDbContext(string[] args)
        {
            var connectionString = "Host=192.168.237.70; Database=CursoApi; Username=postgres; Password=admin";
            var optionsBuilder = new DbContextOptionsBuilder<EnderecosContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new EnderecosContext(optionsBuilder.Options);
        }
    }
}