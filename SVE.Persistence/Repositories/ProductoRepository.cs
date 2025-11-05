using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Application.Contracts.Repositories;

namespace SVE.Persistence.Repositories
{

    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(SVEContext context) : base(context)
        {
        }

        // Para guardar un producto
        public async Task<OperationResult> SaveEntityAsync(Producto entity)
        {
            if (entity == null)
                return new OperationResult { Success = false, Message = "El producto no puede estar vacío." };

            if (string.IsNullOrWhiteSpace(entity.Nombre))
                return new OperationResult { Success = false, Message = "El nombre del producto es obligatorio." };

            if (entity.Precio <= 0)
                return new OperationResult { Success = false, Message = "El precio debe ser mayor a 0." };

            await _context.Productos.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Producto guardado correctamente.", Data = entity };
        }

        // Para actualizar un producto
        public async Task<OperationResult> UpdateEntityAsync(Producto entity)
        {
            var existente = await _context.Productos.FindAsync(entity.Id);
            if (existente == null)
                return new OperationResult { Success = false, Message = "No se encontró el producto a actualizar." };

            existente.Nombre = entity.Nombre;
            existente.Categoria = entity.Categoria;
            existente.Precio = entity.Precio;

            _context.Productos.Update(existente);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Producto actualizado correctamente.", Data = existente };
        }

        // Para buscar productos por el nombre
        public OperationResult GetProductoByNombre(string nombre)
        {
            var productos = _context.Productos.Where(p => p.Nombre.Contains(nombre)).ToList();
            return new OperationResult { Success = true, Data = productos };
        }

        // Para buscar productos por categoría
        public OperationResult GetProductoByCategoria(string categoria)
        {
            var productos = _context.Productos.Where(p => p.Categoria == categoria).ToList();
            return new OperationResult { Success = true, Data = productos };
        }

        // Para buscar productos por el precio
        public OperationResult GetProductoByPrecio(decimal precio)
        {
            var productos = _context.Productos.Where(p => p.Precio == precio).ToList();
            return new OperationResult { Success = true, Data = productos };
        }
    }
}
