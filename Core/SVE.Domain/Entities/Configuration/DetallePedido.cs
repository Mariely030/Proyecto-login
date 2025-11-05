using SVE.Domain.Base;

namespace SVE.Domain.Entities.Configuration
{
    public class DetallePedido : BaseEntity
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;
        public Promocion Promocion { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}