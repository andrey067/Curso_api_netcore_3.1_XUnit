using Application.Interfaces;
using Domain.Dtos.Uf;
using Domain.Entities;
using Domain.Repository;
using Domain.Shared;
using Mapster;

namespace Application.Services
{
    public class UfService : IUfService
    {
        private readonly IRepository<Uf> _repositoryBase;

        public UfService(IRepository<Uf> repositoryBase)
        => _repositoryBase = repositoryBase;

        public async Task<Result<IEnumerable<UfDto>>> GetAll()
        {
            var listEntity = await _repositoryBase.SelectAsyncAll();

            if (listEntity.Any())
                return Result<IEnumerable<UfDto>>.Success(listEntity.Adapt<IEnumerable<UfDto>>());
            else
                return Result<IEnumerable<UfDto>>.Success();
        }

        public async Task<Result<UfDto>> GetById(long id)
        {
            var entity = await _repositoryBase.SelectAsync(id);
            if (entity is null)
                return Result<UfDto>.Success();
            else
                return Result<UfDto>.Success(entity.Adapt<UfDto>());
        }
    }
}
