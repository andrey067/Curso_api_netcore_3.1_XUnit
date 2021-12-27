using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _userDbSet;

        public UserImplementation(MyContext context) : base(context)
        {
            _userDbSet = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email) => await _userDbSet.FirstOrDefaultAsync(u => u.Email.Equals(email));

    }
}
