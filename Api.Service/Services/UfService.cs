using Api.Domain.Interfaces;
using AutoMapper;
using Domain.Dtos.Uf;
using Domain.Entities;
using Domain.Interfaces.Uf;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UfService : IUfService
    {
        private readonly IUfRepository _repository;
        private readonly IMapper _mapper;

        public UfService(IUfRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UfDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UfDto>(entity);
        }

        public async Task<IEnumerable<UfDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsyncAll();
            return _mapper.Map<IEnumerable<UfDto>>(listEntity);
        }
    }
}
