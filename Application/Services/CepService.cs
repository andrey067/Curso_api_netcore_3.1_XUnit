using Application.Dtos.Cep;
using Application.Interfaces;
using Domain.Dtos.Cep;
using Domain.Entities;
using Domain.Repository;
using Domain.Shared;
using Mapster;

namespace Application.Services
{
    public class CepService : ICepService
    {
        private readonly ICepRepository _ceprepository;
        private readonly IRepository<Cep> _baseRepository;

        public CepService(ICepRepository ceprepository, IRepository<Cep> baseRepository)
        {
            _ceprepository = ceprepository;
            _baseRepository = baseRepository;
        }

        public async Task<Result<CepDto>> Get(long id)
        {
            var entity = await _baseRepository.SelectAsync(id);
            if (entity is null)
                return Result<CepDto>.Success();

            return Result<CepDto>.Success(entity.Adapt<CepDto>());
        }

        public async Task<Result<CepDto>> GetByCep(string cep)
        {
            var entity = await _ceprepository.SelectByCepAsync(cep);
            if (entity is null)
                return Result<CepDto>.Success();

            return Result<CepDto>.Success(entity.Adapt<CepDto>());
        }

        public async Task<Result<CepDto>> Post(CreateCepDto cep)
        {
            var entity = new Cep(cep.NumeroCep, cep.Logradouro, cep.Numero, cep.MunicipioId);
            //Todo - adicionar validação de dominio

            var result = await _baseRepository.InsertAsync(entity);

            return Result<CepDto>.Success(result.Adapt<CepDto>());
        }

        public async Task<Result<CepDto>> Put(UpdateCepDto cep)
        {
            var entity = cep.Adapt<Cep>();
            //Todo - Adicionar validacao de dominio
            var result = await _baseRepository.UpdateAsync(entity);
            return Result<CepDto>.Success(result.Adapt<CepDto>());
        }

        public async Task<Result> Delete(long id) => await _baseRepository.DeleteAsync(id) ? Result.Success() : Result.Failure();
    }
}
