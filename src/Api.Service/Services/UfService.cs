using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Repositories;
using AutoMapper;

namespace service.Services;

public class UfService : IUfService
{
  private readonly IUfRepository _repository;
  private readonly IMapper _mapper;

  public UfService(IUfRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<UfDto> Get(Guid id)
  {
    var ufEntity = await _repository.SelectAsync(id);
    return _mapper.Map<UfDto>(ufEntity);
  }

  public async Task<IEnumerable<UfDto>> GetAll()
  {
    var ufEntityList = await _repository.SelectAsync();
    return _mapper.Map<IEnumerable<UfDto>>(ufEntityList);
  }
}
