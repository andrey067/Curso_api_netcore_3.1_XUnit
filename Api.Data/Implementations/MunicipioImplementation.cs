using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _municipioDbeSet;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            _municipioDbeSet = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            return await _municipioDbeSet.Include(m => m.Uf)
                                         .FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid id)
        {
            return await _municipioDbeSet.Include(m => m.Uf)
                                         .FirstOrDefaultAsync(m => m.Id.Equals(id));
        }
    }
}
