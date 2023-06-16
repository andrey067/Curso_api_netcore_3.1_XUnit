using Application.Dtos.Municipio;
using Application.Interfaces;
using Domain.Dtos.Municipio;
using Domain.Entities;
using Domain.Repository;
using Domain.Shared;
using Mapster;

namespace Application.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IRepository<Municipio> _repositoryBase;

        public MunicipioService(IMunicipioRepository municipioRepository, IRepository<Municipio> repositoryBase)
        {
            _municipioRepository = municipioRepository;
            _repositoryBase = repositoryBase;
        }

        public async Task<Result> Delete(long id) => await _repositoryBase.DeleteAsync(id) ? Result.Success() : Result.Failure();

        public async Task<Result<IEnumerable<MunicipioDto>>> GetAll()
        {
            var listEntity = await _repositoryBase.SelectAsyncAll();

            if (listEntity.Any())
                return Result<IEnumerable<MunicipioDto>>.Success();
            else
                return Result<IEnumerable<MunicipioDto>>.Success(listEntity.Adapt<IEnumerable<MunicipioDto>>());
        }

        public async Task<Result<MunicipioDto>> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _municipioRepository.GetCompleteByIBGE(codIBGE);
            if (entity is null)
                return Result<MunicipioDto>.Success();
            else
                return Result<MunicipioDto>.Success(entity.Adapt<MunicipioDto>());
        }

        public async Task<Result<MunicipioDto>> GetCompleteById(long id)
        {
            var entity = await _municipioRepository.GetCompleteById(id);
            if (entity is null)
                return Result<MunicipioDto>.Success();
            else
                return Result<MunicipioDto>.Success(entity.Adapt<MunicipioDto>());
        }

        public async Task<Result<MunicipioDto>> Post(CreateMunicipioDto municipioDtoCreate)
        {
            var entity = new Municipio(municipioDtoCreate.nome, municipioDtoCreate.codIBGE, municipioDtoCreate.UfId);
            //Todo - fazer validacao de dominio

            var result = await _repositoryBase.InsertAsync(entity);

            return Result<MunicipioDto>.Success(result.Adapt<MunicipioDto>());
        }

        public async Task<Result<MunicipioDto>> Put(UpdateMunicipioDto municipioDtoCreate)
        {
            var entity = municipioDtoCreate.Adapt<Municipio>();
            var result = await _repositoryBase.UpdateAsync(entity);

            return Result<MunicipioDto>.Success(result.Adapt<MunicipioDto>());
        }
    }
}
