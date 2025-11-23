using SVE.Application.Common;
using SVE.Application.Dtos.Network.NetworkType;

public interface INetworkTypeApi
{
    Task<ApiResponse<List<GetNetworkTypeDtos>>> GetAllAsync();
    Task<ApiResponse<GetNetworkTypeDtos>> GetByIdAsync(int id);
    Task<ApiResponse<bool>> CreateAsync(CreateNetworkTypeDtos dto);
    Task<ApiResponse<bool>> UpdateAsync(ModifyNetworkTypeDtos dto);
    Task<ApiResponse<bool>> DisableAsync(int id);
}
