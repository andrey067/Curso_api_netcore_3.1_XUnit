using Application.Dtos.Cep;
using Domain.Dtos.Cep;
using Domain.Shared;

namespace Application.Interfaces
{
    public interface ICepService
    {
        Task<Result<CepDto>> Get(long id);
        Task<Result<CepDto>> GetByCep(string cep);
        Task<Result<CepDto>> Post(CreateCepDto cep);
        Task<Result<CepDto>> Put(UpdateCepDto cep);
        Task<Result> Delete(long id);
    }
}
