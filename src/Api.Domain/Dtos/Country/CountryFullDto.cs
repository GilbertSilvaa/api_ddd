using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.Country
{
    public class CountryFullDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }

        public UfDto Uf { get; set; } = null!;
    }
}
