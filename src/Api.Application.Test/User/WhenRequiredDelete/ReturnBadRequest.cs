using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.User.WhenRequiredDelete
{
    public class ReturnBadRequest
    {
        private UsersController? _controller;

        [Fact(DisplayName = "Is not possible execute delete")]
        public async Task IsNotPossibleCallControllerDelete()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Invalid format");

            var result = await _controller.Delete(default);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
