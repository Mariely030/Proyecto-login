using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Domain.Base;

namespace SVE.Persistence.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(SVEContext context) : base(context)
        {
        }

        public OperationResult GetProductoByNombre(string nombre)
        {
            var productos = _context.Productos
                                     .Where(p => p.Nombre.Contains(nombre))
                                     .ToList();
            return new OperationResult { Success = true, Data = productos };
        }

        public OperationResult GetProductoByPrecio(decimal precio)
        {
            var productos = _context.Productos
                                     .Where(p => p.Precio == precio)
                                     .ToList();
            return new OperationResult { Success = true, Data = productos };
        }

        public OperationResult GetProductoByCategoria(string categoria)
        {
            var productos = _context.Productos
                                     .Where(p => p.Categoria == categoria)
                                     .ToList();
            return new OperationResult { Success = true, Data = productos };
        }
    }
}
