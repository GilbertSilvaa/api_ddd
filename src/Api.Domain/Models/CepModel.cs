namespace Api.Domain.Models
{
    public class CepModel : BaseModel
    {
        private string _cep = null!;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _logradouro = null!;
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        private string _number = null!;
        public string Number
        {
            get { return _number; }
            set { _number = string.IsNullOrEmpty(value) ? "S/N" : value; }
        }

        private Guid _countryId;
        public Guid CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }

    }
}
