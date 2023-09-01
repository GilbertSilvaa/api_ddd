using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.User
{
    public class WhenIsExecutedCreate : UserTest
    {
        private IUserService? _service;
        private Mock<IUserService>? _serviceMock;

        [Fact(DisplayName = "Is it possible to execute the create method")]
        public async Task IsPossibleToExecuteMethodCreate()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userCreateDto)).ReturnsAsync(userCreateResultDto);
            _service = _serviceMock.Object;

            var result = await _service.Post(userCreateDto);
            Assert.NotNull(result);
            Assert.Equal(NameUser, result.Name);
            Assert.Equal(EmailUser, result.Email);
        }
    }
}
