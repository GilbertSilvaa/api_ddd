using Moq;
using Api.Domain.Dtos.User;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Test.User.WhenRequiredGet
{
    public class ReturnGet
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is possible execute get method")]
        public async Task IsPossibleCallControllerGet()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .ReturnsAsync(new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                });

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(email, resultValue.Email);
            Assert.Equal(name, resultValue.Name);
        }
    }
}
