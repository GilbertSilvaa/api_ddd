using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.User.WhenRequiredUpdate
{
    public class ReturnUpdated
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is possible execute update")]
        public async Task IsPossibleCallControllerUpdate()
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

            var userUpdateDto = new UserUpdateDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _controller.Put(userUpdateDto);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserUpdateResultDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Email, userUpdateDto.Email);
            Assert.Equal(resultValue.Name, userUpdateDto.Name);
        }
    }
}
