using SVE.Application.Dtos;
using SVE.Application.Base;

namespace SVE.Application.Interfaces
{

    public interface IProductoService
    {
        
        Task<ServiceResult> GetProductos();
        Task<ServiceResult> GetProductoById(int id);
        Task<ServiceResult> CreateProducto(CreateProductoDto dto);
        Task<ServiceResult> UpdateProducto(UpdateProductoDto dto);
        Task<ServiceResult> RemoveProducto(RemoveProductoDto dto);
    
    }
}