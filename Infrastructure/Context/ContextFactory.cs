using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<EnderecosContext>
    {
        public EnderecosContext CreateDbContext(string[] args)
        {
            //if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            //{
            //    serviceCollection.AddDbContext<MyContext>(
            //options => options
            //.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            //}
            //else
            //{
            //    //ConectionString MySQL
            //    serviceCollection.AddDbContext<MyContext>(
            //    options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            //}


            //Usado para fazer as migrações
            //var connectionString = "Server=localhost;Port=3306;Database=dbApi;Uid=root;Pwd=mudar@123";            
            //var connectionString = "Data Source=ADMDTI09;Initial Catalog=dbapi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CursoApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            var optionsBuilder = new DbContextOptionsBuilder<EnderecosContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new EnderecosContext(optionsBuilder.Options);
        }
    }

}