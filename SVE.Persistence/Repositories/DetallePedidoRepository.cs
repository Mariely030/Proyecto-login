using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Application.Contracts.Repositories;

namespace SVE.Persistence.Repositories
{
    public class DetallePedidoRepository : BaseRepository<DetallePedido>, IDetallePedidoRepository
    {
        public DetallePedidoRepository(SVEContext context) : base(context)
        {
        }

        // Para guardar detalles del pedido con sus validaciones

        public async Task<OperationResult> SaveEntityAsync(DetallePedido entity)
        {
            if (entity == null)
                return new OperationResult { Success = false, Message = "El detalle del pedido no puede estar vacío." };

            if (entity.Cantidad <= 0)
                return new OperationResult { Success = false, Message = "La cantidad debe ser mayor a 0." };

            if (entity.PrecioUnitario <= 0)
                return new OperationResult { Success = false, Message = "El precio unitario debe ser mayor a 0." };

            await _context.DetallePedidos.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Detalle del pedido guardado correctamente.", Data = entity };
        }

        // Para actualizar detalles del pedido

        public async Task<OperationResult> UpdateEntityAsync(DetallePedido entity)
        {
            var existente = await _context.DetallePedidos.FindAsync(entity.Id);
            if (existente == null)
                return new OperationResult { Success = false, Message = "No se encontró el detalle del pedido a actualizar." };

            existente.Cantidad = entity.Cantidad;
            existente.PrecioUnitario = entity.PrecioUnitario;
            existente.ProductoId = entity.ProductoId;
            existente.PedidoId = entity.PedidoId;

            _context.DetallePedidos.Update(existente);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Detalle del pedido actualizado correctamente.", Data = existente };
        }

        // Metodos
       
        public OperationResult GetDetallePedidoByPedidoId(int pedidoId)
        {

            var detalles = _context.DetallePedidos.Where(d => d.PedidoId == pedidoId).ToList();
            return new OperationResult { Success = true, Data = detalles };
        }

        public OperationResult GetDetallePedidoByProductoId(int productoId)
        {
            var detalles = _context.DetallePedidos.Where(d => d.ProductoId == productoId).ToList();
            return new OperationResult { Success = true, Data = detalles };
        }

        public OperationResult GetDetallePedidoByCantidad(int cantidad)
        {

            var detalles = _context.DetallePedidos.Where(d => d.Cantidad == cantidad).ToList();
            return new OperationResult { Success = true, Data = detalles };
        }

        public OperationResult GetDetallePedidoByPrecioUnitario(decimal precio)
        {

            var detalles = _context.DetallePedidos.Where(d => d.PrecioUnitario == precio).ToList();
            return new OperationResult { Success = true, Data = detalles };
        }
    }
}



