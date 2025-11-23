using Microsoft.AspNetCore.Mvc;
using Moq;
using SVE.Web.Controllers;
using SVE.Application.Contracts;
using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Application.Dtos.Network.NetworkType;
using SVE.Application.Common;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SVE.Web.Test.Controllers
{
    public class NetworkProviderControllerTest
    {
        private readonly Mock<INetworkProviderApi> _providerApiMock;
        private readonly Mock<INetworkTypeApi> _typeApiMock;
        private readonly NetworkProviderController _controller;

        public NetworkProviderControllerTest()
        {
            _providerApiMock = new Mock<INetworkProviderApi>();
            _typeApiMock = new Mock<INetworkTypeApi>();
            _controller = new NetworkProviderController(_providerApiMock.Object, _typeApiMock.Object);
        }

        [Fact]
        public async Task Index_ReturnsView_WithData()
        {
            // Mock del API
            _providerApiMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new ApiResponse<List<GetNetworkProviderDtos>>
                {
                    Success = true,
                    Data = new List<GetNetworkProviderDtos>
                    {
                        new GetNetworkProviderDtos { Id = 1, Nombre = "Claro" }
                    }
                });

            var result = await _controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.NotNull(result.Model);
        }

       [Fact]
public async Task Create_Post_RedirectsOnSuccess()
{
    var model = new CreateNetworkProviderDtos
    {
        Nombre = "Altice",
        NetworkTypeId = 1
    };

    // Mock necesario: GetByIdAsync
    _typeApiMock.Setup(x => x.GetByIdAsync(1))
        .ReturnsAsync(new ApiResponse<GetNetworkTypeDtos>
        {
            Success = true,
            Data = new GetNetworkTypeDtos { Id = 1, Nombre = "Fibra" }
        });

    // Este puede quedarse
    _typeApiMock.Setup(x => x.GetAllAsync())
        .ReturnsAsync(new ApiResponse<List<GetNetworkTypeDtos>>
        {
            Success = true,
            Data = new List<GetNetworkTypeDtos>
            {
                new GetNetworkTypeDtos { Id = 1, Nombre = "Fibra" }
            }
        });

    _providerApiMock.Setup(x => x.CreateAsync(model))
        .ReturnsAsync(new ApiResponse<bool>
        {
            Success = true,
            Data = true
        });

    var result = await _controller.Create(model);

    Assert.IsType<RedirectToActionResult>(result);
}

        [Fact]
        public async Task Edit_Get_ReturnsView_WhenExists()
        {
            _providerApiMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new ApiResponse<GetNetworkProviderDtos>
                {
                    Success = true,
                    Data = new GetNetworkProviderDtos
                    {
                        Id = 1,
                        Nombre = "Claro",
                        NetworkTypeId = 2,
                        Description = "desc"
                    }
                });

            _typeApiMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new ApiResponse<List<GetNetworkTypeDtos>>
                {
                    Success = true,
                    Data = new List<GetNetworkTypeDtos>
                    {
                        new GetNetworkTypeDtos { Id = 2, Nombre = "Fibra" }
                    }
                });

            var result = await _controller.Edit(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
public async Task Edit_Post_RedirectsOnSuccess()
{
    var model = new ModifyNetworkProviderDtos
    {
        Id = 1,
        Nombre = "Altice",
        NetworkTypeId = 1
    };

    // Mock GetByIdAsync requerido por el controller
    _providerApiMock.Setup(x => x.GetByIdAsync(1))
        .ReturnsAsync(new ApiResponse<GetNetworkProviderDtos>
        {
            Success = true,
            Data = new GetNetworkProviderDtos
            {
                Id = 1,
                Nombre = "Altice",
                NetworkTypeId = 1,
                Description = "Descripción existente"
            }
        });

    _providerApiMock.Setup(x => x.UpdateAsync(model))
        .ReturnsAsync(new ApiResponse<bool>
        {
            Success = true,
            Data = true
        });

    _typeApiMock.Setup(x => x.GetAllAsync())
        .ReturnsAsync(new ApiResponse<List<GetNetworkTypeDtos>>
        {
            Success = true,
            Data = new List<GetNetworkTypeDtos>
            {
                new GetNetworkTypeDtos { Id = 1, Nombre = "Fibra" }
            }
        });

    var result = await _controller.Edit(model);

    Assert.IsType<RedirectToActionResult>(result);
}

        [Fact]
        public async Task Disable_RedirectsOnSuccess()
        {
            _providerApiMock.Setup(x => x.DisableAsync(It.IsAny<int>()))
                .ReturnsAsync(new ApiResponse<bool>
                {
                    Success = true,
                    Data = true
                });

            var result = await _controller.Disable(1);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsView_WhenExists()
        {
            var dto = new GetNetworkProviderDtos
            {
                Id = 1,
                Nombre = "Viva",
                NetworkTypeId = 1,
                Description = "desc"
            };

            _providerApiMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new ApiResponse<GetNetworkProviderDtos>
                {
                    Success = true,
                    Data = dto
                });

            var result = await _controller.Details(1) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(dto, result!.Model);
        }
    }
}
