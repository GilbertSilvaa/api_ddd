using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.User.WhenRequiredUpdate
{
    public class ReturnBadRequest
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is not possible execute update")]
        public async Task IsNotPossibleCallControllerUpdate()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserUpdateDto>()))
                .ReturnsAsync(new UserUpdateResultDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "This field is required");

            var userUpdateDto = new UserUpdateDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _controller.Put(userUpdateDto);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
