using SVE.Domain.Repository;
using SVE.Domain.Entities.Configuration;

namespace SVE.Application.Repositories
{

    public interface IProductoRepository : IBaseRepository<Producto>
    {

        List<Producto> GetProductoByNombre(string Nombre);
        List<Producto> GetProductoByPrecio(decimal Precio);
        List<Producto> GetProductoByCategoria(string Categoria);
    }
}