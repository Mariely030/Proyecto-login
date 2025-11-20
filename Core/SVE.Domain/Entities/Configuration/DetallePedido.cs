using SVE.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SVE.Domain.Entities.Configuration
{
    public class DetallePedido : BaseEntity
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;
        public int PromocionId { get; set; }
        public Promocion Promocion { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }
    }
}