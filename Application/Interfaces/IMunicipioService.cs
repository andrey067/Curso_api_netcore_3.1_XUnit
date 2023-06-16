using Application.Dtos.Municipio;
using Domain.Dtos.Municipio;
using Domain.Shared;

namespace Application.Interfaces
{
    public interface IMunicipioService
    {        
        Task<Result<MunicipioDto>> GetCompleteById(long Id);
        Task<Result<MunicipioDto>> GetCompleteByIBGE(int codIBGE);
        Task<Result<IEnumerable<MunicipioDto>>> GetAll();
        Task<Result<MunicipioDto>> Post(CreateMunicipioDto municipioDtoCreate);
        Task<Result<MunicipioDto>> Put(UpdateMunicipioDto municipioDtoCreate);
        Task<Result> Delete(long Id);
    }
}
