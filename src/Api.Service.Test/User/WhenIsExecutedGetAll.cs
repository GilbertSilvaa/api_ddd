using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.User
{
    public class WhenIsExecutedGetAll : UserTest
    {
        private IUserService? _service;
        private Mock<IUserService>? _serviceMock;

        [Fact(DisplayName = "Is it possible to execute the getAll method")]
        public async Task IsPossibleToExecuteMethodGetAll()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(userDtoList);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _resultList = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_resultList.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
