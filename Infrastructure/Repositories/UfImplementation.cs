using Api.Domain.Entities;
using Domain.Entities;
using Domain.Repository;
using System.Data.Entity;

namespace Data.Implementations
{
    public class UfImplementation : IUfRepository
    {
        private readonly IRepository<Uf> _repository;

        public UfImplementation(IRepository<Uf> repository) => _repository = repository;

        public async Task<Uf> FindBySigla(string sigla)
            => await _repository.GetDbSet().FirstOrDefaultAsync(u => u.Sigla == sigla);
    }
}
