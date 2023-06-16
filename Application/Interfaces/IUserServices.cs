using Application.Dtos.Users;
using Domain.Dtos.User;
using Domain.Shared;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<Result<UserDto>> Get(long id);

        Task<Result<IEnumerable<UserDto>>> GetAll();

        Task<Result<UserDto>> Post(CreateUserDto entity);

        Task<Result<UserDto>> Put(UpdateUserDto entity);

        Task<Result> Delete(long id);
    }
}
