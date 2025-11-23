using Xunit;
using SVE.Application.Common;
using SVE.Application.Dtos.Network.NetworkType;
using RichardSzalay.MockHttp;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Threading.Tasks;

public class NetworkTypeApiTests
{
    private readonly NetworkTypeApi _api;
    private readonly MockHttpMessageHandler _mockHttp;

    public NetworkTypeApiTests()
    {
        _mockHttp = new MockHttpMessageHandler();

        var httpClient = new HttpClient(_mockHttp)
        {
            BaseAddress = new Uri("http://localhost")
        };

        _api = new NetworkTypeApi(httpClient);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsData()
    {
        var response = new ApiResponse<List<GetNetworkTypeDtos>>
        {
            Success = true,
            Data = new List<GetNetworkTypeDtos>
            {
                new GetNetworkTypeDtos { Id = 1, Nombre ="FIBRA" }
            }
        };

        _mockHttp.When("http://localhost/api/NetworkType")
                 .Respond("application/json", JsonSerializer.Serialize(response));

        var result = await _api.GetAllAsync();

        Assert.NotNull(result.Data);
        Assert.Single(result.Data);
    }
}


