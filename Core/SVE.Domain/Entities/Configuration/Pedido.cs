using SVE.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SVE.Domain.Entities.Configuration
{
    public class Pedido : BaseEntity
    {

        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}