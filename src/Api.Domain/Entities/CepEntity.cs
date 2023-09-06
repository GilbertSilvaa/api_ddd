using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; } = null!;

        [MaxLength(10)]
        public string Number { get; set; } = null!;

        [Required]
        public Guid CountryId { get; set; }

        public CountryEntity Country { get; set; } = null!;
    }
}
