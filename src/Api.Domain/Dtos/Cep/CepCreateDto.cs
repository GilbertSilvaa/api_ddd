using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepCreateDto
    {
        [Required(ErrorMessage = "CEP field is required")]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "Logradouro field is required")]
        public string Logradouro { get; set; } = null!;

        public string Number { get; set; } = null!;

        [Required(ErrorMessage = "Country field is required")]
        public Guid CountryId { get; set; }
    }
}
