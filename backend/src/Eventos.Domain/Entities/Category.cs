using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eventos.Domain.Entities.Base;

namespace Eventos.Domain.Entities
{
    [Table("categories")]
    public class Category : BaseEntity
    {
        [Required, Column("description")]
        public string Description { get; set; }
    }
}
