namespace Api.Domain.Dtos.Cep
{
    public class CepUpdateResultDto
    {
        public Guid Id { get; set; }
        public string Cep { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
        public string Number { get; set; } = null!;
        public Guid CountryId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
