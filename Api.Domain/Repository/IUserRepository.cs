using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> FindByLogin(string email);

    }
}
