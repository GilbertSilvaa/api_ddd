namespace Api.Domain.Dtos.Country
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
    }
}
