using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.Login
{
    public class WhenIsExecutedFindByLogin
    {
        private ILoginService? _service;
        private Mock<ILoginService>? _serviceMock;

        [Fact(DisplayName = "Is it possible to execute the FindByLogin method")]
        public async Task IsPossibleToExecuteMethodFindByLogin()
        {
            string _email = Faker.Internet.Email();
            var _responseObj = new
            {
                authenticated = true,
                created = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = DateTime.UtcNow.AddHours(2).ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = Guid.NewGuid(),
                userName = _email,
                message = "User logged in successfully."
            };

            LoginDto _loginDto = new() { Email = _email };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(_loginDto)).ReturnsAsync(_responseObj);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(_loginDto);
            Assert.NotNull(result);
        }
    }
}
