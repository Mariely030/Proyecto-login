using SVE.Application.Common;
using SVE.Application.Dtos.Network.NetworkType;

public class NetworkTypeApi : ApiClient, INetworkTypeApi
{
    private const string baseUrl = "api/NetworkType";

    public NetworkTypeApi(HttpClient http) : base(http) { }

    public Task<ApiResponse<List<GetNetworkTypeDtos>>> GetAllAsync()
        => GetAsync<List<GetNetworkTypeDtos>>(baseUrl);

    public Task<ApiResponse<GetNetworkTypeDtos>> GetByIdAsync(int id)
        => GetAsync<GetNetworkTypeDtos>($"{baseUrl}/{id}");

    public Task<ApiResponse<bool>> CreateAsync(CreateNetworkTypeDtos dto)
        => PostAsync<bool>(baseUrl, dto);

    public Task<ApiResponse<bool>> UpdateAsync(ModifyNetworkTypeDtos dto)
        => PutAsync<bool>(baseUrl, dto);

    public Task<ApiResponse<bool>> DisableAsync(int id)
        => DeleteAsync<bool>($"{baseUrl}/{id}");
}


