using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.User.WhenRequiredGetAll
{
    public class ReturnGetAll
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is possible execute getAll method")]
        public async Task IsPossibleCallControllerGetAll()
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

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<UserDto>;
            Assert.True(resultValue?.Count() == 5);
        }
    }
}
