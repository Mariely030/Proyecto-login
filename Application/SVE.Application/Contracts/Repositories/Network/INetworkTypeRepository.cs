using SVE.Application.Dtos.Network.NetworkType;
using SVE.Domain.Base;

namespace SVE.Application.Contracts.Repositories.Network
{

    public interface INetworkTypeRepository
    {
        Task<OperationResult> AddAsync(CreateNetworkTypeDtos dtos);
        Task<OperationResult> UpdateAsync(ModifyNetworkTypeDtos dtos);
        Task<OperationResult> DeleteAsync(DisableNetworkTypeDtos dtos);
        Task<OperationResult> GetByIdAsync(int id);
        Task<OperationResult> GetAllAsync();
    }
}