using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity>, ICepRepository
    {
        private DbSet<CepEntity> _cepDbeSet;

        public CepImplementation(MyContext context) : base(context)
        {
            _cepDbeSet = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _cepDbeSet
                .Include(c => c.Municipio)
                .ThenInclude(m => m.Uf).SingleOrDefaultAsync(u => u.Cep.Equals(cep));
        }
    }
}
