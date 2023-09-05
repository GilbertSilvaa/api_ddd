using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseTest
    {
        [Fact(DisplayName = "Is it possible to mapper models")]
        public void IsPossibleToMapperModels()
        {
            UserModel _model = new()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var _entityList = new List<UserEntity>();
            for (int i = 0; i < 8; i++)
            {
                UserEntity item = new()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                _entityList.Add(item);
            }

            // Model => Entity
            var _entity = Mapper.Map<UserEntity>(_model);
            Assert.Equal(_entity.Id, _model.Id);
            Assert.Equal(_entity.Name, _model.Name);
            Assert.Equal(_entity.Email, _model.Email);
            Assert.Equal(_entity.CreateAt, _model.CreateAt);
            Assert.Equal(_entity.UpdateAt, _model.UpdateAt);

            // Entity => Dto
            var _userDto = Mapper.Map<UserDto>(_entity);
            Assert.Equal(_userDto.Id, _entity.Id);
            Assert.Equal(_userDto.Name, _entity.Name);
            Assert.Equal(_userDto.Email, _entity.Email);
            Assert.Equal(_userDto.CreateAt, _entity.CreateAt);

            var _dtoList = Mapper.Map<List<UserDto>>(_entityList);
            Assert.True(_dtoList.Count() == _entityList.Count());

            foreach (var (_dtoUser, i) in _dtoList.Select((value, i) => (value, i)))
            {
                Assert.Equal(_dtoUser.Id, _entityList[i].Id);
                Assert.Equal(_dtoUser.Name, _entityList[i].Name);
                Assert.Equal(_dtoUser.Email, _entityList[i].Email);
                Assert.Equal(_dtoUser.CreateAt, _entityList[i].CreateAt);
            }

            var _userUpdateResultDto = Mapper.Map<UserUpdateResultDto>(_entity);
            Assert.Equal(_userUpdateResultDto.Id, _entity.Id);
            Assert.Equal(_userUpdateResultDto.Name, _entity.Name);
            Assert.Equal(_userUpdateResultDto.Email, _entity.Email);
            Assert.Equal(_userUpdateResultDto.UpdateAt, _entity.UpdateAt);

            // Dto => Model
            var _userModel = Mapper.Map<UserModel>(_userDto);
            Assert.Equal(_userModel.Id, _userDto.Id);
            Assert.Equal(_userModel.Name, _userDto.Name);
            Assert.Equal(_userModel.Email, _userDto.Email);
            Assert.Equal(_userModel.CreateAt, _userDto.CreateAt);

            var _userCreateDto = Mapper.Map<UserCreateDto>(_userModel);
            Assert.Equal(_userCreateDto.Name, _userModel.Name);
            Assert.Equal(_userCreateDto.Email, _userModel.Email);

            var _userUpdateDto = Mapper.Map<UserUpdateDto>(_userModel);
            Assert.Equal(_userUpdateDto.Id, _userModel.Id);
            Assert.Equal(_userUpdateDto.Name, _userModel.Name);
            Assert.Equal(_userUpdateDto.Email, _userModel.Email);
        }
    }
}
