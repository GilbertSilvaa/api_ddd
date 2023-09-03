using Moq;
using Api.Domain.Dtos.User;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Test.User.WhenRequiredGet
{
    public class ReturnBadRequest
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is not possible execute get method")]
        public async Task IsNotPossibleCallControllerGet()
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
            _controller.ModelState.AddModelError("Id", "Invalid format");

            var result = await _controller.Get(default);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
