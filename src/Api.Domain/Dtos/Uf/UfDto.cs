namespace Api.Domain.Dtos.Uf
{
    public class UfDto
    {
        public Guid Id { get; set; }
        public string Abbreviation { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
