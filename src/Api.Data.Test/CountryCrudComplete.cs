using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class CountryCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private readonly ServiceProvider _serviceProvider;

        public CountryCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Country CRUD")]
        [Trait("CRUD", "CountryEntity")]
        public async Task IsPossibleCrudCountry()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            CountryImplemetation _repository = new(context!);
            CountryEntity _countryEntity = new()
            {
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            // Country create in crud
            var _registerCreated = await _repository.InsertAsync(_countryEntity);
            Assert.NotNull(_registerCreated);
            Assert.Equal(_countryEntity.Name, _registerCreated.Name);
            Assert.Equal(_countryEntity.CodIBGE, _registerCreated.CodIBGE);
            Assert.Equal(_countryEntity.UfId, _registerCreated.UfId);
            Assert.False(_countryEntity.Id == Guid.Empty);

            // Country update in crud
            _countryEntity.Id = _registerCreated.Id;
            _countryEntity.Name = Faker.Address.City();
            var _registerUpdated = await _repository.UpdateAsync(_countryEntity);
            Assert.NotNull(_registerUpdated);
            Assert.Equal(_countryEntity.Name, _registerUpdated.Name);
            Assert.Equal(_countryEntity.CodIBGE, _registerUpdated.CodIBGE);
            Assert.Equal(_countryEntity.UfId, _registerUpdated.UfId);

            // Verify if country exist
            var _registerExist = await _repository.ExistAsync(_registerUpdated.Id);
            Assert.True(_registerExist);

            // Country select by Id in crud
            var _registerSelected = await _repository.SelectAsync(_registerUpdated.Id);
            Assert.NotNull(_registerSelected);
            Assert.Equal(_registerUpdated.Name, _registerSelected.Name);
            Assert.Equal(_registerUpdated.CodIBGE, _registerSelected.CodIBGE);
            Assert.Equal(_registerUpdated.UfId, _registerSelected.UfId);
            Assert.Null(_registerSelected.Uf);

            // Country select complete by codIBGE in crud
            _registerSelected = await _repository.GetFullByIBGE(_registerUpdated.CodIBGE);
            Assert.NotNull(_registerSelected);
            Assert.Equal(_registerUpdated.Name, _registerSelected.Name);
            Assert.Equal(_registerUpdated.CodIBGE, _registerSelected.CodIBGE);
            Assert.Equal(_registerUpdated.UfId, _registerSelected.UfId);
            Assert.NotNull(_registerSelected.Uf);

            // Country select complete by Id in crud
            _registerSelected = await _repository.GetFullById(_registerUpdated.Id);
            Assert.NotNull(_registerSelected);
            Assert.Equal(_registerUpdated.Name, _registerSelected.Name);
            Assert.Equal(_registerUpdated.CodIBGE, _registerSelected.CodIBGE);
            Assert.Equal(_registerUpdated.UfId, _registerSelected.UfId);
            Assert.NotNull(_registerSelected.Uf);

            // Country select all in crud
            var _allRegisterList = await _repository.SelectAsync();
            Assert.NotNull(_allRegisterList);
            Assert.True(_allRegisterList.Count() > 0);

            // Coutry delete in crud
            var _isDeleted = await _repository.DeleteAsync(_registerSelected.Id);
            Assert.True(_isDeleted);
        }
    }
}
