using Api.Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UserImplementation : IUserRepository
    {
        private readonly IRepository<User> _repository;

        public UserImplementation(IRepository<User> repository) => _repository = repository;

        public async Task<User?> FindByLogin(string email) => await _repository.GetDbSet().FirstOrDefaultAsync(u => u.Email.Equals(email));
    }
}
