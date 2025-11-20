using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Application.Base;

namespace SVE.Application.Contracts.Services.Network
{
    public interface INetworkProviderService
    {
        Task<ServiceResult> GetAllAsync();
        Task<ServiceResult> GetByIdAsync(int id);
        Task<ServiceResult> AddAsync(CreateNetworkProviderDtos dtos);
        Task<ServiceResult> UpdateAsync(ModifyNetworkProviderDtos dtos);
        Task<ServiceResult> DeleteAsync(DisableNetworkProviderDtos dtos);
    }
}

