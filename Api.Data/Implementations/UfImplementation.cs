using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UfImplementation : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _ufDbeSet;

        public UfImplementation(MyContext context) : base(context)
        {
            _ufDbeSet = context.Set<UfEntity>();
        }
    }
}
