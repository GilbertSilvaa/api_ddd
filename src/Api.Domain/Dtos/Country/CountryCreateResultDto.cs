namespace Api.Domain.Dtos.Country
{
    public class CountryCreateResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
        public DateTime CraeteAt { get; set; }
    }
}
