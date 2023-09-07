using Api.Domain.Dtos.Country;

namespace Api.Domain.Interfaces.Services.Country
{
    public interface ICountryService
    {
        Task<CountryDto> Get(Guid id);
        Task<CountryFullDto> GetFullById(Guid id);
        Task<CountryFullDto> GetFullByIBGE(int codIBGE);
        Task<IEnumerable<CountryDto>> GetAll();
        Task<CountryCreateResultDto> Post(CountryCreateDto country);
        Task<CountryUpdateResultDto> Put(CountryUpdateResultDto country);
        Task<bool> Delete(Guid id);
    }
}
