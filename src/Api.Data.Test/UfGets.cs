using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class UfGets : BaseTest, IClassFixture<DbTest>
    {
        private readonly ServiceProvider _serviceProvider;

        public UfGets(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Gets Uf")]
        [Trait("Gets", "UfEntity")]
        public async Task IsPossibleGetsUf()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            UfImplemetation _repository = new(context!);
            UfEntity _ufEntity = new()
            {
                Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                Abbreviation = "SP",
                Name = "São Paulo"
            };

            var _registerExist = await _repository.ExistAsync(_ufEntity.Id);
            Assert.True(_registerExist);

            var _registerSelected = await _repository.SelectAsync(_ufEntity.Id);
            Assert.NotNull(_registerSelected);
            Assert.Equal(_ufEntity.Abbreviation, _registerSelected.Abbreviation);
            Assert.Equal(_ufEntity.Name, _registerSelected.Name);
            Assert.Equal(_ufEntity.Id, _registerSelected.Id);

            var _allRegisterList = await _repository.SelectAsync();
            Assert.NotNull(_allRegisterList);
            Assert.True(_allRegisterList.Count().Equals(27));
        }
    }
}
