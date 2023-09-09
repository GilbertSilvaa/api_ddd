using Api.Data.Context;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CepImplemetation : BaseRepository<CepEntity>, ICepRepository
    {
        private readonly DbSet<CepEntity> _dataSet;

        public CepImplemetation(MyContext context) : base(context)
        {
            _dataSet = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            var response = await _dataSet
                .Include(c => c.Country)
                .ThenInclude(c => c.Uf)
                .FirstOrDefaultAsync(c => c.Cep.Equals(cep));

            return response!;
        }
    }
}
