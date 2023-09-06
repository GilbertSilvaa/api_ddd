using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Abbreviation { get; set; } = null!;

        [Required]
        [MaxLength(45)]
        public string Name { get; set; } = null!;

        public IEnumerable<CountryEntity> Countries { get; set; } = null!;
    }
}
