using SVE.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SVE.Domain.Entities.Configuration
{

    public class Producto : BaseEntity
    {
        public string Nombre { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = null!;
    }
}