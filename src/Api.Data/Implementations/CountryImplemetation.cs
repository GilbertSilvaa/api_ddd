using Api.Data.Context;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CountryImplemetation : BaseRepository<CountryEntity>, ICountryRepository
    {
        private readonly DbSet<CountryEntity> _dataSet;

        public CountryImplemetation(MyContext context) : base(context)
        {
            _dataSet = context.Set<CountryEntity>();
        }

        public async Task<CountryEntity> GetFullByIBGE(int codIBGE)
        {
            var response = await _dataSet
                .Include(c => c.Uf)
                .FirstOrDefaultAsync(c => c.CodIBGE.Equals(codIBGE));

            return response!;
        }

        public async Task<CountryEntity> GetFullById(Guid id)
        {
            var response = await _dataSet
                .Include(c => c.Uf)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));

            return response!;
        }
    }
}
