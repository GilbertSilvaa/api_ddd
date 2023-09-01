using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var userEntityList = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(userEntityList);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var userEntity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(userEntity) ?? new UserDto();
        }

        public async Task<UserCreateResultDto> Post(UserCreateDto user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var userEntity = _mapper.Map<UserEntity>(userModel);

            var userResult = await _repository.InsertAsync(userEntity);
            return _mapper.Map<UserCreateResultDto>(userResult);
        }

        public async Task<UserUpdateResultDto> Put(UserUpdateDto user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var userEntity = _mapper.Map<UserEntity>(userModel);

            var userResult = await _repository.UpdateAsync(userEntity);
            return _mapper.Map<UserUpdateResultDto>(userResult);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
