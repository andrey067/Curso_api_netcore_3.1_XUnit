using Domain.Dtos;
using System.Threading.Tasks;

namespace Domain.Interfaces.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
