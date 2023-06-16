using Domain.Entities;
using Domain.Repository;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CepImplementation : ICepRepository
    {
        private readonly IRepository<Cep> _repositoryBase;

        public CepImplementation(IRepository<Cep> repositoryBase)
            => _repositoryBase = repositoryBase;


        public async Task<Cep?> SelectByCepAsync(string cep)
        => await _repositoryBase.GetDbSet()
                .Include(c => c.Municipio)
                .ThenInclude(m => m.Uf).SingleOrDefaultAsync(u => u.NumeroCep.Equals(cep));
    }
}
