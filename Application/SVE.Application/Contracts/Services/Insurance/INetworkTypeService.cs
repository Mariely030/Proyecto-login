using SVE.Application.Dtos.Insurance.NetworkType;
using SVE.Domain.Base;

namespace SVE.Application.Contracts.Services.Insurance
{

    public interface INetworkTypeService
    {

        Task<OperationResult> AddAsync(CreateNetworkTypeDtos dtos);
        Task<OperationResult> UpdateAsync(ModifyNetworkTypeDtos dtos);
        Task<OperationResult> DeleteAsync(DisableNetworkTypeDtos dtos);
        Task<OperationResult> GetByIdAsync(int id);
        Task<OperationResult> GetAllAsync();
    }
} 