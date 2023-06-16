using Api.Domain.Entities;
using Domain.Entities;
using Infrastructure.TableMapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class EnderecosContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cep> Cep { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Uf> UF { get; set; }

        public EnderecosContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Uf>(new UfMapping().Configure);
            modelBuilder.Entity<Cep>(new CepMapping().Configure);
            modelBuilder.Entity<Municipio>(new MunicipioMapping().Configure);
        }

    }
}