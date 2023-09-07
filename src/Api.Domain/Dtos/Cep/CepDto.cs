using Api.Domain.Dtos.Country;

namespace Api.Domain.Dtos.Cep
{
    public class CepDto
    {
        public Guid Id { get; set; }
        public string Cep { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
        public string Number { get; set; } = null!;
        public Guid CountryId { get; set; }

        public CountryFullDto Country { get; set; } = null!;
    }
}
