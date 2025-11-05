using SVE.Domain.Repository;
using SVE.Domain.Entities.Configuration;

namespace SVE.Application.Repositories
{

    public interface IPedidoRepository : IBaseRepository<Pedido>
    {

        List<Pedido> GetPedidoByUsuarioId(int UsuarioId);
        List<Pedido> GetPedidoByFecha(DateTime Fecha);
        List<Pedido> GetPedidoByEstado(string Estado);
        List<Pedido> GetPedidoByTotal(decimal Total);
    }
}