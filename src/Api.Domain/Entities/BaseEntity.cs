using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? UpdateAt { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value ?? DateTime.UtcNow; }
        }
    }
}
