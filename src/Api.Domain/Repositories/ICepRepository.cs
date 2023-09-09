using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repositories
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
    }
}
