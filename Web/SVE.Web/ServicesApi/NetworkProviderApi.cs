using SVE.Application.Common;
using SVE.Application.Dtos.Network.NetworkProvider;

public class NetworkProviderApi : ApiClient, INetworkProviderApi
{
    private const string baseUrl = "api/NetworkProvider";

    public NetworkProviderApi(HttpClient http) : base(http) { }

    public Task<ApiResponse<List<GetNetworkProviderDtos>>> GetAllAsync()
        => GetAsync<List<GetNetworkProviderDtos>>(baseUrl);

    public Task<ApiResponse<GetNetworkProviderDtos>> GetByIdAsync(int id)
        => GetAsync<GetNetworkProviderDtos>($"{baseUrl}/{id}");

    public Task<ApiResponse<bool>> CreateAsync(CreateNetworkProviderDtos dto)
        => PostAsync<bool>(baseUrl, dto);

    public Task<ApiResponse<bool>> UpdateAsync(ModifyNetworkProviderDtos dto)
        => PutAsync<bool>(baseUrl, dto);

    public Task<ApiResponse<bool>> DisableAsync(int id)
        => DeleteAsync<bool>($"{baseUrl}/{id}");
}

