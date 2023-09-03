using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.User.WhenRequiredGetAll
{
    public class ReturnBadRequest
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is not possible execute getAll method")]
        public async Task IsNotPossibleCallControllerGetAll()
        {
            var serviceMock = new Mock<IUserService>();

            List<UserDto> userDtoList = new();

            for (int i = 0; i < 5; i++)
            {
                userDtoList.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                });
            }

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(userDtoList);
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("", "Invalid Format");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
