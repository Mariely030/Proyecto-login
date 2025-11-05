using SVE.Domain.Entities.Configuration;
using SVE.Domain.Base;

namespace SVE.Application.Contracts.Repositories
{

    public interface IProductoRepository : IBaseRepository<Producto>
    {

        OperationResult GetProductoByNombre(string Nombre);
        OperationResult GetProductoByPrecio(decimal Precio);
        OperationResult GetProductoByCategoria(string Categoria);
    }
}