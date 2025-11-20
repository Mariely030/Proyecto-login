using SVE.Application.Dtos.Configuration;
using SVE.Application.Interfaces;
using SVE.Application.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Application.Contracts.Repositories;

namespace SVE.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<ServiceResult> GetProductos()
        {
            var result = new ServiceResult();
            try
            {
                var productos = await _productoRepository.GetAllAsync();
                result.Success = true;
                result.Data = productos;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetProductoById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var producto = await _productoRepository.GetByIdAsync(id);
                if (producto == null)
                {
                    result.Success = false;
                    result.Message = "Producto no encontrado";
                }
                else
                {
                    result.Success = true;
                    result.Data = producto;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> CreateProducto(CreateProductoDto dto)
{
    var result = new ServiceResult();
    try
    {
        var producto = new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria
        };

        await _productoRepository.AddAsync(producto);
        await _productoRepository.SaveChangesAsync(); // <-- guardar en DB

        result.Success = true;
        result.Message = "Producto creado correctamente";
        result.Data = producto;
    }
    catch (Exception ex)
    {
        result.Success = false;
        result.Message = ex.Message;
    }
    return result;
}

public async Task<ServiceResult> UpdateProducto(UpdateProductoDto dto)
{
    var result = new ServiceResult();
    try
    {
        var producto = await _productoRepository.GetByIdAsync(dto.Id);
        if (producto == null)
        {
            result.Success = false;
            result.Message = "Producto no encontrado";
            return result;
        }

        producto.Nombre = dto.Nombre;
        producto.Precio = dto.Precio;
        producto.Categoria = dto.Categoria;

        _productoRepository.Update(producto);
        await _productoRepository.SaveChangesAsync(); // <-- guardar cambios

        result.Success = true;
        result.Message = "Producto actualizado correctamente";
        result.Data = producto;
    }
    catch (Exception ex)
    {
        result.Success = false;
        result.Message = ex.Message;
    }
    return result;
}

public async Task<ServiceResult> RemoveProducto(RemoveProductoDto dto)
{
    var result = new ServiceResult();
    try
    {
        var producto = await _productoRepository.GetByIdAsync(dto.Id);
        if (producto == null)
        {
            result.Success = false;
            result.Message = "Producto no encontrado";
            return result;
        }

        _productoRepository.Delete(producto);
        await _productoRepository.SaveChangesAsync(); // <-- guardar cambios

        result.Success = true;
        result.Message = "Producto eliminado correctamente";
        result.Data = producto;
    }
    catch (Exception ex)
    {
        result.Success = false;
        result.Message = ex.Message;
    }
    return result;
}

    }
}
