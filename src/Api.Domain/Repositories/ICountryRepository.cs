using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repositories
{
    public interface ICountryRepository : IRepository<CountryEntity>
    {
        Task<CountryEntity> GetFullById(Guid id);
        Task<CountryEntity> GetFullByIBGE(int codIBGE);
    }
}
