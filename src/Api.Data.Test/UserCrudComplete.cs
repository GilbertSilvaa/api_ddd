using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private readonly ServiceProvider _serviceProvider;

        public UserCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD User")]
        [Trait("CRUD", "UserEntity")]
        public async Task IsPossibleCrudUser()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            UserImplementation _repository = new(context!);
            UserEntity _userEntity = new()
            {
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName()
            };

            // User create in crud
            var _registerCreated = await _repository.InsertAsync(_userEntity);
            Assert.NotNull(_registerCreated);
            Assert.Equal(_userEntity.Email, _registerCreated.Email);
            Assert.Equal(_userEntity.Name, _registerCreated.Name);
            Assert.False(_registerCreated.Id == Guid.Empty);

            // User update in crud
            _userEntity.Name = Faker.Name.First();
            var _registerUpdated = await _repository.UpdateAsync(_userEntity);
            Assert.NotNull(_registerUpdated);
            Assert.Equal(_userEntity.Email, _registerUpdated.Email);
            Assert.Equal(_userEntity.Name, _registerUpdated.Name);

            // Verify if user exist
            var _registerExist = await _repository.ExistAsync(_registerUpdated.Id);
            Assert.True(_registerExist);

            // User select by Id in crud
            var _registerSelected = await _repository.SelectAsync(_registerUpdated.Id);
            Assert.NotNull(_registerSelected);
            Assert.Equal(_registerUpdated.Email, _registerSelected.Email);
            Assert.Equal(_registerUpdated.Name, _registerSelected.Name);

            // User select all in crud
            var _allRegisterList = await _repository.SelectAsync();
            Assert.NotNull(_allRegisterList);
            Assert.True(_allRegisterList.Count() > 0);

            // User login method 
            var _userLogin = await _repository.FindByLogin(_registerSelected.Email);
            Assert.NotNull(_userLogin);
            Assert.Equal(_registerSelected.Email, _userLogin.Email);
            Assert.Equal(_registerSelected.Name, _userLogin.Name);

            // User delete in crud
            var _isDeleted = await _repository.DeleteAsync(_registerSelected.Id);
            Assert.True(_isDeleted);
        }
    }
}
