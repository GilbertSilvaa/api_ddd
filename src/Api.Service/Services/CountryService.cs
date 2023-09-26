using Api.Domain.Dtos.Country;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Country;
using Api.Domain.Models;
using Api.Domain.Repositories;
using AutoMapper;

namespace service.Services;

public class CountryService : ICountryService
{
  private readonly ICountryRepository _repository;
  private readonly IMapper _mapper;

  public CountryService(ICountryRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<CountryDto>> GetAll()
  {
    var countryEntityList = await _repository.SelectAsync();
    return _mapper.Map<IEnumerable<CountryDto>>(countryEntityList);
  }

  public async Task<CountryDto> Get(Guid id)
  {
    var countryEntity = await _repository.SelectAsync(id);
    return _mapper.Map<CountryDto>(countryEntity);
  }

  public async Task<CountryFullDto> GetFullById(Guid id)
  {
    var countryEntity = await _repository.GetFullById(id);
    return _mapper.Map<CountryFullDto>(countryEntity);
  }

  public async Task<CountryFullDto> GetFullByIBGE(int codIBGE)
  {
    var countryEntity = await _repository.GetFullByIBGE(codIBGE);
    return _mapper.Map<CountryFullDto>(countryEntity);
  }

  public async Task<CountryCreateResultDto> Post(CountryCreateDto country)
  {
    var countryModel = _mapper.Map<CountryModel>(country);
    var countryEntity = _mapper.Map<CountryEntity>(countryModel);

    var result = await _repository.InsertAsync(countryEntity);
    return _mapper.Map<CountryCreateResultDto>(result);
  }

  public async Task<CountryUpdateResultDto> Put(CountryUpdateDto country)
  {
    var countryModel = _mapper.Map<CountryModel>(country);
    var countryEntity = _mapper.Map<CountryEntity>(countryModel);

    var countryResult = await _repository.UpdateAsync(countryEntity);
    return _mapper.Map<CountryUpdateResultDto>(countryResult);
  }

  public async Task<bool> Delete(Guid id)
  {
    return await _repository.DeleteAsync(id);
  }
}
