using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.User
{
    public class WhenIsExecutedUpdate : UserTest
    {
        private IUserService? _service;
        private Mock<IUserService>? _serviceMock;

        [Fact(DisplayName = "Is it possible to execute the update method")]
        public async Task IsPossibleToExecuteMethodUpdate()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userCreateDto)).ReturnsAsync(userCreateResultDto);
            _service = _serviceMock.Object;

            var result = await _service.Post(userCreateDto);
            Assert.NotNull(result);
            Assert.Equal(NameUser, result.Name);
            Assert.Equal(EmailUser, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userUpdateDto)).ReturnsAsync(userUpdateResultDto);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userUpdateDto);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NameUserModified, resultUpdate.Name);
            Assert.Equal(EmailUserModified, resultUpdate.Email);
        }
    }
}
