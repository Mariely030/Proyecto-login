using SVE.Application.Dtos;
using SVE.Application.Base;

namespace SVE.Application.Interfaces
{

    public interface IDetallePedidoService
    {
        
        Task<ServiceResult> GetDetallePedido();
        Task<ServiceResult> GetDetallePedidoById(int id);
        Task<ServiceResult> CreateDetallePedido(CreateDetallePedidoDto dto);
        Task<ServiceResult> UpdateDetallePedido(UpdateDetallePedidoDto dto);
        Task<ServiceResult> RemoveDetallePedido(RemoveDetallePedidoDto dto);
    }
}