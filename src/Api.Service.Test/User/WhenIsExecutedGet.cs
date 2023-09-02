using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Test.User;
using Moq;

namespace Api.Service.Test
{
    public class WhenIsExecutedGet : UserTest
    {
        private IUserService? _service;
        private Mock<IUserService>? _serviceMock;

        [Fact(DisplayName = "Is it possible to execute the get method")]
        public async Task IsPossibleToExecuteMethodGet()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUser)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUser);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUser);
            Assert.Equal(NameUser, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m =>
                m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null!));

            _service = _serviceMock.Object;
            var _record = await _service.Get(IdUser);
            Assert.Null(_record);
        }
    }
}
