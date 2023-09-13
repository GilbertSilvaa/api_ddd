using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Models;
using Api.Domain.Repositories;
using AutoMapper;

namespace service.Services;

public class CepService : ICepService
{
  private readonly ICepRepository _repository;
  private readonly IMapper _mapper;

  public CepService(ICepRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<CepDto> Get(Guid id)
  {
    var cepEntity = await _repository.SelectAsync(id);
    return _mapper.Map<CepDto>(cepEntity);
  }

  public async Task<CepDto> Get(string cep)
  {
    var cepEntity = await _repository.SelectAsync(cep);
    return _mapper.Map<CepDto>(cepEntity);
  }

  public async Task<CepCreateResultDto> Post(CepCreateDto cep)
  {
    var cepModel = _mapper.Map<CepModel>(cep);
    var cepEntity = _mapper.Map<CepEntity>(cepModel);

    var cepResult = await _repository.InsertAsync(cepEntity);
    return _mapper.Map<CepCreateResultDto>(cepResult);
  }

  public async Task<CepUpdateResultDto> Put(CepUpdateDto cep)
  {
    var cepModel = _mapper.Map<CepModel>(cep);
    var cepEntity = _mapper.Map<CepEntity>(cepModel);

    var cepResult = await _repository.UpdateAsync(cepEntity);
    return _mapper.Map<CepUpdateResultDto>(cepResult);
  }

  public async Task<bool> Delete(Guid id)
  {
    return await _repository.DeleteAsync(id);
  }
}
