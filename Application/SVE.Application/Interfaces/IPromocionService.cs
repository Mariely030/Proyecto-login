using SVE.Application.Dtos;
using SVE.Application.Base;

namespace SVE.Application.Interfaces
{

    public interface IPromocionService
    {
        
        Task<ServiceResult> GetPromociones();
        Task<ServiceResult> GetPromocionById(int id);
        Task<ServiceResult> CreatePromocion(CreatePromocionDto dto);
        Task<ServiceResult> UpdatePromocion(UpdatePromocionDto dto);
        Task<ServiceResult> RemovePromocion(RemovePromocionDto dto);
    }
}