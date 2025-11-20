using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Domain.Base;

namespace SVE.Persistence.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(SVEContext context) : base(context)
        {
        }

        public OperationResult GetPedidoByUsuarioId(int usuarioId)
        {
            var pedidos = _context.Pedidos
                                  .Where(p => p.UsuarioId == usuarioId)
                                  .ToList();
            return new OperationResult { Success = true, Data = pedidos };
        }

        public OperationResult GetPedidoByFecha(DateTime fecha)
        {
            var pedidos = _context.Pedidos
                                  .Where(p => p.Fecha.Date == fecha.Date)
                                  .ToList();
            return new OperationResult { Success = true, Data = pedidos };
        }

        public OperationResult GetPedidoByEstado(string estado)
        {
            var pedidos = _context.Pedidos
                                  .Where(p => p.Estado == estado)
                                  .ToList();
            return new OperationResult { Success = true, Data = pedidos };
        }

        public OperationResult GetPedidoByTotal(decimal total)
        {
            var pedidos = _context.Pedidos
                                  .Where(p => p.Total == total)
                                  .ToList();
            return new OperationResult { Success = true, Data = pedidos };
        }
    }
}

