using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Name field is required")]
        [StringLength(60, ErrorMessage = "Name can be a maximum of {1} characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email field is required")]
        [StringLength(100, ErrorMessage = "Email can be a maximum of {1} characters.")]
        public string Email { get; set; } = null!;
    }
}
