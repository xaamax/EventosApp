using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.Domain.Entities.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
