using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class CepCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private readonly ServiceProvider _serviceProvider;

        public CepCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Cep CRUD")]
        [Trait("CRUD", "CepEntity")]
        public async Task IsPossibleCrudCep()
        {
            using var context = _serviceProvider.GetService<MyContext>();

            CountryImplemetation _countryRepository = new(context!);
            CountryEntity _countryEntity = new()
            {
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            var _registerCountryCreated = await _countryRepository.InsertAsync(_countryEntity);
            Assert.NotNull(_registerCountryCreated);
            Assert.Equal(_countryEntity.Name, _registerCountryCreated.Name);
            Assert.Equal(_countryEntity.CodIBGE, _registerCountryCreated.CodIBGE);
            Assert.Equal(_countryEntity.UfId, _registerCountryCreated.UfId);
            Assert.False(_countryEntity.Id == Guid.Empty);

            CepImplemetation _repository = new(context!);
            CepEntity _cepEntity = new()
            {
                Cep = "13.481-001",
                Number = "0 até 2000",
                Logradouro = Faker.Address.StreetName(),
                CountryId = _registerCountryCreated.Id
            };

            // Cep create in crud
            var _registerCreated = await _repository.InsertAsync(_cepEntity);
            Assert.NotNull(_registerCreated);
            Assert.Equal(_cepEntity.Cep, _registerCreated.Cep);
            Assert.Equal(_cepEntity.Logradouro, _registerCreated.Logradouro);
            Assert.Equal(_cepEntity.Number, _registerCreated.Number);
            Assert.Equal(_cepEntity.CountryId, _registerCreated.CountryId);
            Assert.False(_cepEntity.Id == Guid.Empty);

            // Cep update in crud
            _cepEntity.Logradouro = Faker.Address.StreetName();
            _cepEntity.Id = _registerCreated.Id;
            var _registerUpdated = await _repository.UpdateAsync(_cepEntity);
            Assert.NotNull(_registerUpdated);
            Assert.Equal(_cepEntity.Cep, _registerUpdated.Cep);
            Assert.Equal(_cepEntity.Logradouro, _registerUpdated.Logradouro);
            Assert.Equal(_cepEntity.CountryId, _registerUpdated.CountryId);
            Assert.True(_registerUpdated.Id == _registerCreated.Id);

            // Verify if cep exist
            var _registerExist = await _repository.ExistAsync(_registerUpdated.Id);
            Assert.True(_registerExist);

            // Cep select by Id in crud
            var _registerSelected = await _repository.SelectAsync(_registerUpdated.Id);
            Assert.Equal(_registerUpdated.Cep, _registerSelected.Cep);
            Assert.Equal(_registerUpdated.Logradouro, _registerSelected.Logradouro);
            Assert.Equal(_registerUpdated.Number, _registerSelected.Number);
            Assert.Equal(_registerUpdated.CountryId, _registerSelected.CountryId);

            // Cep select by Cep in crud
            _registerSelected = await _repository.SelectAsync(_registerUpdated.Cep);
            Assert.Equal(_registerUpdated.Cep, _registerSelected.Cep);
            Assert.Equal(_registerUpdated.Logradouro, _registerSelected.Logradouro);
            Assert.Equal(_registerUpdated.Number, _registerSelected.Number);
            Assert.Equal(_registerUpdated.CountryId, _registerSelected.CountryId);
            Assert.NotNull(_registerSelected.Country);
            Assert.Equal(_countryEntity.Name, _registerSelected.Country.Name);
            Assert.NotNull(_registerSelected.Country.Uf);

            // Cep select all in crud
            var _allRegisterList = await _repository.SelectAsync();
            Assert.NotNull(_allRegisterList);
            Assert.True(_allRegisterList.Count() > 0);

            // Cep delete in crud
            var _isDeleted = await _repository.DeleteAsync(_registerSelected.Id);
            Assert.True(_isDeleted);

            // Cep select empty list
            _allRegisterList = await _repository.SelectAsync();
            Assert.NotNull(_allRegisterList);
            Assert.True(_allRegisterList.Count() == 0);
        }
    }
}
