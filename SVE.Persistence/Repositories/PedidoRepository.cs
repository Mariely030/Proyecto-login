using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Application.Contracts.Repositories;

namespace SVE.Persistence.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(SVEContext context) : base(context)
        {
        }

        // Para guardar un pedido con sus validaciones

        public async Task<OperationResult> SaveEntityAsync(Pedido entity)
        {

            if (entity == null)
                return new OperationResult { Success = false, Message = "El pedido no puede estar vacío." };

            if (string.IsNullOrWhiteSpace(entity.Estado))
                return new OperationResult { Success = false, Message = "El estado del pedido es obligatorio." };

            await _context.Pedidos.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Pedido guardado correctamente.", Data = entity };
        }

        //Para actualizar un pedido

        public async Task<OperationResult> UpdateEntityAsync(Pedido entity)
        {

            var existente = await _context.Pedidos.FindAsync(entity.Id);
            if (existente == null)
                return new OperationResult { Success = false, Message = "No se encontró el pedido a actualizar." };

            existente.Estado = entity.Estado;
            existente.Fecha = entity.Fecha;
            existente.UsuarioId = entity.UsuarioId;
            existente.Total = entity.Total;

            _context.Pedidos.Update(existente);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Pedido actualizado correctamente.", Data = existente };
        }

        // Para buscar pedido por el total

        public OperationResult GetPedidoByTotal(decimal total)
        {

            var pedidos = _context.Pedidos.Where(p => p.Total == total).ToList();
            return new OperationResult { Success = true, Data = pedidos };
        }

        // Para buscar pedido por el estado

        public OperationResult GetPedidoByEstado(string estado)
        {

            var pedidos = _context.Pedidos.Where(p => p.Estado == estado).ToList();
            return new OperationResult { Success = true, Data = pedidos };
        }

        // Para buscar pedido por el usuario

        public OperationResult GetPedidoByUsuarioId(int usuarioId)
        {

            var pedidos = _context.Pedidos.Where(p => p.UsuarioId == usuarioId).ToList();
            return new OperationResult { Success = true, Data = pedidos };
        }

        // Para buscar pedido por fecha

        public OperationResult GetPedidoByFecha(DateTime fecha)
        {

            var pedidos = _context.Pedidos
            .Where(p => p.Fecha.Date == fecha.Date)
            .ToList();

            return new OperationResult
            {

                Success = true,
                Data = pedidos
            };
        }
    }
}
