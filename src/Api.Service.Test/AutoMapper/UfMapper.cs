using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Service.Test.AutoMapper;

public class UfMapper : BaseTest
{
  [Fact(DisplayName = "Is it possible to mapper models Uf")]
  public void IsPossibleToMapperModelsUf()
  {
    UfModel _model = new()
    {
      Id = Guid.NewGuid(),
      Name = Faker.Address.UsState(),
      Abbreviation = Faker.Address.UsState().Substring(1, 3),
      CreateAt = DateTime.UtcNow,
      UpdateAt = DateTime.UtcNow
    };

    var _entityList = new List<UfEntity>();
    for (int i = 0; i < 8; i++)
    {
      UfEntity item = new()
      {
        Id = Guid.NewGuid(),
        Name = Faker.Address.UsState(),
        Abbreviation = Faker.Address.UsState().Substring(1, 3),
        CreateAt = DateTime.UtcNow,
        UpdateAt = DateTime.UtcNow
      };
      _entityList.Add(item);
    }

    // Model => Entity
    var _entity = Mapper.Map<UfEntity>(_model);
    Assert.Equal(_entity.Id, _model.Id);
    Assert.Equal(_entity.Name, _model.Name);
    Assert.Equal(_entity.Abbreviation, _model.Abbreviation);
    Assert.Equal(_entity.CreateAt, _model.CreateAt);
    Assert.Equal(_entity.UpdateAt, _model.UpdateAt);

    // Entity => Dto
    var _ufDto = Mapper.Map<UfDto>(_entity);
    Assert.Equal(_ufDto.Id, _entity.Id);
    Assert.Equal(_ufDto.Name, _entity.Name);
    Assert.Equal(_ufDto.Abbreviation, _entity.Abbreviation);

    var _dtoList = Mapper.Map<List<UfDto>>(_entityList);
    Assert.True(_dtoList.Count() == _entityList.Count());

    foreach (var (_dtoUf, i) in _dtoList.Select((value, i) => (value, i)))
    {
      Assert.Equal(_dtoUf.Id, _entityList[i].Id);
      Assert.Equal(_dtoUf.Name, _entityList[i].Name);
      Assert.Equal(_dtoUf.Abbreviation, _entityList[i].Abbreviation);
    }

    // Dto => Model
    var _UfModel = Mapper.Map<UfModel>(_ufDto);
    Assert.Equal(_UfModel.Id, _ufDto.Id);
    Assert.Equal(_UfModel.Name, _ufDto.Name);
    Assert.Equal(_UfModel.Abbreviation, _ufDto.Abbreviation);
  }
}
