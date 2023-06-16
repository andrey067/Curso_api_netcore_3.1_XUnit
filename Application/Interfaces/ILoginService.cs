using Application.Dtos.Login;
using Domain.Shared;

namespace Application.Interfaces
{
    public interface ILoginService
    {
        Task<Result<object>> FindByLogin(LoginDto user);
    }
}
