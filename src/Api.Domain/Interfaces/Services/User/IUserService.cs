using Api.Domain.Dtos.User;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserCreateResultDto> Post(UserDto user);
        Task<UserUpdateResultDto> Put(UserDto user);
        Task<bool> Delete(Guid id);
    }
}
