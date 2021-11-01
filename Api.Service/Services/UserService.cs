using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class UserService : IUserServices
    {
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetGetAll(Guid id)
        {
            return await _repository.SelectAsyncAll();
        }

        public async Task<UserEntity> Post(UserEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<UserEntity> Put(UserEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}