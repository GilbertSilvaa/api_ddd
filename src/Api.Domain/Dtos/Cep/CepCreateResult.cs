namespace Api.Domain.Dtos.Cep
{
    public class CepCreateResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
        public string Number { get; set; } = null!;
        public Guid CountryId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
