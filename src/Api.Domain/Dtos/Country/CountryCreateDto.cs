using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Country
{
    public class CountryCreateDto
    {
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = null!;

        [Range(0, int.MaxValue)]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public Guid UfId { get; set; }
    }
}
