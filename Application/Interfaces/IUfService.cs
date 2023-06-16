using Domain.Dtos.Uf;
using Domain.Shared;

namespace Application.Interfaces
{
    public interface IUfService
    {
        Task<Result<UfDto>> GetById(long id);
        Task<Result<IEnumerable<UfDto>>> GetAll();
    }
}
