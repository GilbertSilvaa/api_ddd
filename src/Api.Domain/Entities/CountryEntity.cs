using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CountryEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = null!;
        public int CodIBGE { get; set; }

        [Required]
        public Guid UfId { get; set; }
        public UfEntity Uf { get; set; } = null!;

        public IEnumerable<CepEntity> Ceps { get; set; } = null!;
    }
}
