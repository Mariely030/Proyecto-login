using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Application.Common;

public interface INetworkProviderApi
{
    Task<ApiResponse<List<GetNetworkProviderDtos>>> GetAllAsync();
    Task<ApiResponse<GetNetworkProviderDtos>> GetByIdAsync(int id);
    Task<ApiResponse<bool>> CreateAsync(CreateNetworkProviderDtos dto);
    Task<ApiResponse<bool>> UpdateAsync(ModifyNetworkProviderDtos dto);
    Task<ApiResponse<bool>> DisableAsync(int id);
}
