using SVE.Domain.Entities.Configuration;
using SVE.Domain.Base;

namespace SVE.Application.Contracts.Repositories
{

    public interface IPedidoRepository : IBaseRepository<Pedido>
    {

        OperationResult GetPedidoByUsuarioId(int UsuarioId);
        OperationResult GetPedidoByFecha(DateTime Fecha);
        OperationResult GetPedidoByEstado(string Estado);
        OperationResult GetPedidoByTotal(decimal Total);
    }
}