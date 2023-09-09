using Api.Data.Context;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UfImplemetation : BaseRepository<UfEntity>, IUfRepository
    {
        private readonly DbSet<UfEntity> _dataSet;

        public UfImplemetation(MyContext context) : base(context)
        {
            _dataSet = context.Set<UfEntity>();
        }
    }
}
