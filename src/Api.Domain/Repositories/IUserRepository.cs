using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
