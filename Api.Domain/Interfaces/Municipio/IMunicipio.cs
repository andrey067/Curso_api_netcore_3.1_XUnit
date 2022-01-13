using Domain.Dtos.Municipio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Municipio
{
    public interface IMunicipio
    {
        Task<MunicipioDto> Get(Guid Id);
        Task<MunicipioDtoCompleto> GetCompleteById(Guid Id);
        Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAll();
        Task<MunicipioCreateResult> Post(MunicipioDtoCreate municipioDtoCreate);
        Task<MunicipioDtoUpdateResult> Post(MunicipioDtoUpdate municipioDtoCreate);
        Task<bool> Delete(Guid Id);
    }
}
