using Api.Domain.Entities;
using Application.Dtos.Users;
using Application.Interfaces;
using Domain.Dtos.User;
using Domain.Repository;
using Domain.Shared;
using Mapster;

namespace Application.Services
{
    public class UserService : IUserServices
    {
        private IUserRepository _userRepository;
        private readonly IRepository<User> _repositoryBase;

        public UserService(IUserRepository userRepository, IRepository<User> repositoryBase)
        {
            _userRepository = userRepository;
            _repositoryBase = repositoryBase;
        }

        public async Task<Result> Delete(long id) => await _repositoryBase.DeleteAsync(id) ? Result.Success() : Result.Failure();

        public async Task<Result<UserDto>> Get(long id)
        {
            var user = await _repositoryBase.SelectAsync(id);
            if (user == null)
                return Result<UserDto>.Failure(new Error(typeof(User).Name, "Não encontrado"));

            return Result<UserDto>.Success(user.Adapt<UserDto>());
        }

        public async Task<Result<IEnumerable<UserDto>>> GetAll()
        {
            var entity = await _repositoryBase.SelectAsyncAll();
            if (entity is null)
                return Result<IEnumerable<UserDto>>.Success();

            return Result<IEnumerable<UserDto>>.Success(entity.Adapt<IEnumerable<UserDto>>());
        }

        public async Task<Result<UserDto>> Post(CreateUserDto dto)
        {
            var user = new User(dto.nome, dto.email);
            var result = await _repositoryBase.InsertAsync(user);
            var userDto = result.Adapt<UserDto>();
            return Result<UserDto>.Success(userDto);
        }

        public async Task<Result<UserDto>> Put(UpdateUserDto dto)
        {
            var user = await _repositoryBase.SelectAsync(dto.id);
            if (user == null)
                return Result<UserDto>.Failure(new Error(typeof(User).Name, "Não encontrado"));

            user.AlterarNome(dto.nome);
            user.AlternateEmail(dto.email);
            var result = await _repositoryBase.UpdateAsync(user);
            var updatedUserDto = result.Adapt<UserDto>();
            return Result<UserDto>.Success(updatedUserDto.Adapt<UserDto>());
        }
    }
}