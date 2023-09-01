using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.User
{
    public class WhenIsExecutedDelete : UserTest
    {
        private IUserService? _service;
        private Mock<IUserService>? _serviceMock;

        [Fact(DisplayName = "Is it possible to execute the delete method")]
        public async Task IsPossibleToExecuteMethodDelete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var isDeleted = await _service.Delete(IdUser);
            Assert.True(isDeleted);
        }
    }
}
