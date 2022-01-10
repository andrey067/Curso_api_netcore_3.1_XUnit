using Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserServices
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate entity);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate entity);
        Task<bool> Delete(Guid id);
    }
}