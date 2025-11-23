using RichardSzalay.MockHttp;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;
using SVE.Application.Common;
using SVE.Application.Dtos.Network.NetworkProvider;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NetworkProviderApiTests
{
    private readonly NetworkProviderApi _api;
    private readonly MockHttpMessageHandler _mockHttp;

    public NetworkProviderApiTests()
    {
        _mockHttp = new MockHttpMessageHandler();

        var httpClient = new HttpClient(_mockHttp)
        {
            BaseAddress = new Uri("http://localhost") // <- muy importante
        };

        _api = new NetworkProviderApi(httpClient);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsData()
    {
        var response = new ApiResponse<List<GetNetworkProviderDtos>>
        {
            Success = true,
            Data = new List<GetNetworkProviderDtos>
            {
                new GetNetworkProviderDtos { Id = 1, Nombre ="Claro" }
            }
        };

        // Setup mock
        _mockHttp.When("http://localhost/api/NetworkProvider")
                 .Respond("application/json", JsonSerializer.Serialize(response));

        var result = await _api.GetAllAsync();

        Assert.NotNull(result.Data);
        Assert.Single(result.Data);
    }
}
