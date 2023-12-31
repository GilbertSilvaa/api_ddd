using Api.Domain.Dtos.User;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserCreateResultDto> Post(UserCreateDto user);
        Task<UserUpdateResultDto> Put(UserUpdateDto user);
        Task<bool> Delete(Guid id);
    }
}
