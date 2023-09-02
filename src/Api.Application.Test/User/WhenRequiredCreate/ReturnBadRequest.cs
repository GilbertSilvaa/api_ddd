using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.User.WhenRequiredCreate
{
    public class ReturnBadRequest
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is possible execute created")]
        public async Task IsPossibleCallControllerCreate()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserCreateDto>()))
                .ReturnsAsync(new UserCreateResultDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "This field is required");

            Mock<IUrlHelper> url = new();
            url.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost:4000/users/get");
            _controller.Url = url.Object;

            var userCreateDto = new UserCreateDto
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(userCreateDto);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
