using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class MunicipioImplementation : IMunicipioRepository
    {
        private readonly IRepository<Municipio> _repositoryBase;

        public MunicipioImplementation(IRepository<Municipio> repositoryBase) => _repositoryBase = repositoryBase;

        public async Task<Municipio?> GetCompleteByIBGE(int codIBGE)
        => await _repositoryBase.GetDbSet().Include(m => m.Uf)
                                         .FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));

        public async Task<Municipio?> GetCompleteById(long id)
        => await _repositoryBase.GetDbSet().Include(m => m.Uf)
                                         .FirstOrDefaultAsync(m => m.Id.Equals(id));
    }
}
