using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Data.Repositories;
using Api.Domain.Repositories;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dataSet;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            var response = await _dataSet.FirstOrDefaultAsync(u => u.Email.Equals(email));

            return response!;
        }
    }
}
