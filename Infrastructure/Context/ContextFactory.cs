using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<EnderecosContext>
    {
        public EnderecosContext CreateDbContext(string[] args)
        {
            var connectionString = "";
            var optionsBuilder = new DbContextOptionsBuilder<EnderecosContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new EnderecosContext(optionsBuilder.Options);
        }
    }
}