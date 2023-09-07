namespace Api.Domain.Models
{
    public class UfModel : BaseModel
    {
        private string _abbreviation = null!;
        public string Abbreviation
        {
            get { return _abbreviation; }
            set { _abbreviation = value; }
        }

        private string _name = null!;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
