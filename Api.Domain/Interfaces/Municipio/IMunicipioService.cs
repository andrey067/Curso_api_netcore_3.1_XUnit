using Domain.Dtos.Municipio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid Id);
        Task<MunicipioDtoCompleto> GetCompleteById(Guid Id);
        Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAll();
        Task<MunicipioCreateResult> Post(MunicipioDtoCreate municipioDtoCreate);
        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipioDtoCreate);
        Task<bool> Delete(Guid Id);
    }
}
