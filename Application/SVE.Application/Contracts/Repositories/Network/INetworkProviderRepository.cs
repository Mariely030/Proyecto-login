using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Domain.Base;

namespace SVE.Application.Contracts.Repositories.Network
{
    public interface INetworkProviderRepository
    {
        Task<OperationResult> GetByIdAsync(int id);
        Task<OperationResult> AddAsync(CreateNetworkProviderDtos createDtos);
        Task<OperationResult> UpdateAsync(ModifyNetworkProviderDtos modifyDtos);
        Task<OperationResult> DeleteAsync(DisableNetworkProviderDtos disableDtos);
        Task<OperationResult> GetAllAsync();
    }
}
