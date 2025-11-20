using SVE.Application.Dtos.Configuration;
using SVE.Application.Base;

namespace SVE.Application.Interfaces
{
    
    public interface IPedidoService
    {
        
        Task<ServiceResult> GetPedidos();
        Task<ServiceResult> GetPedidoById(int id);
        Task<ServiceResult> CreatePedido(CreatePedidoDto dto);
        Task<ServiceResult> UpdatePedido(UpdatePedidoDto dto);
        Task<ServiceResult> RemovePedido(RemovePedidoDto dto);
    }
}
