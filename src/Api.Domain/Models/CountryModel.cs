namespace Api.Domain.Models
{
    public class CountryModel : BaseModel
    {
        private string _name = null!;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _codIBGE;
        public int CodIBGE
        {
            get { return _codIBGE; }
            set { _codIBGE = value; }
        }

        private Guid _ufId;
        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }

    }
}
