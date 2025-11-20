using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Domain.Base;

namespace SVE.Persistence.Repositories
{
    public class DetallePedidoRepository : BaseRepository<DetallePedido>, IDetallePedidoRepository
    {
        public DetallePedidoRepository(SVEContext context) : base(context)
        {
        }

        public OperationResult GetDetallePedidoByPedidoId(int pedidoId)
        {
            var detalles = _context.DetallePedidos
                                   .Where(d => d.PedidoId == pedidoId)
                                   .ToList();
            return new OperationResult { Success = true, Data = detalles };
        }

        public OperationResult GetDetallePedidoByProductoId(int productoId)
        {
            var detalles = _context.DetallePedidos
                                   .Where(d => d.ProductoId == productoId)
                                   .ToList();
            return new OperationResult { Success = true, Data = detalles };
        }

        public OperationResult GetDetallePedidoByCantidad(int cantidad)
        {
            var detalles = _context.DetallePedidos
                                   .Where(d => d.Cantidad == cantidad)
                                   .ToList();
            return new OperationResult { Success = true, Data = detalles };
        }

        public OperationResult GetDetallePedidoByPrecioUnitario(decimal precioUnitario)
        {
            var detalles = _context.DetallePedidos
                                   .Where(d => d.PrecioUnitario == precioUnitario)
                                   .ToList();
            return new OperationResult { Success = true, Data = detalles };
        }
    }
}





