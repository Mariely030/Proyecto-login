using Microsoft.AspNetCore.Mvc;
using Moq;
using SVE.Application.Contracts;
using SVE.Application.Dtos.Network.NetworkType;
using SVE.Web.Controllers;

namespace SVE.Web.Test.Controllers
{
    public class NetworkTypeControllerTest
    {
        private readonly Mock<INetworkTypeApi> _apiMock;
        private readonly NetworkTypeController _controller;

        public NetworkTypeControllerTest()
        {
            _apiMock = new Mock<INetworkTypeApi>();
            _controller = new NetworkTypeController(_apiMock.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewWithData()
        {
            var list = new List<GetNetworkTypeDtos>
            {
                new GetNetworkTypeDtos { Id = 1, Nombre = "Fibra" }
            };

            _apiMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new SVE.Application.Common.ApiResponse<List<GetNetworkTypeDtos>>
                {
                    Success = true,
                    Data = list
                });

            var result = await _controller.Index() as ViewResult;
            var model = result!.Model as List<GetNetworkTypeDtos>;

            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Single(model);
        }

        [Fact]
        public async Task Edit_ReturnsView_WithExistingData()
        {
            var dto = new GetNetworkTypeDtos { Id = 1, Nombre = "Fibra" };

            _apiMock.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(new SVE.Application.Common.ApiResponse<GetNetworkTypeDtos>
                {
                    Success = true,
                    Data = dto
                });

            var result = await _controller.Edit(1) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<ModifyNetworkTypeDtos>(result!.Model);
        }

        [Fact]
        public async Task Create_Post_RedirectsOnSuccess()
        {
            var model = new CreateNetworkTypeDtos { Nombre = "Fibra" };

            _apiMock.Setup(x => x.CreateAsync(model))
                .ReturnsAsync(new SVE.Application.Common.ApiResponse<bool>
                {
                    Success = true,
                    Data = true
                });

            var result = await _controller.Create(model);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Edit_Post_RedirectsOnSuccess()
        {
            var model = new ModifyNetworkTypeDtos { Id = 1, Nombre = "Fibra" };

            _apiMock.Setup(x => x.UpdateAsync(model))
                .ReturnsAsync(new SVE.Application.Common.ApiResponse<bool>
                {
                    Success = true,
                    Data = true
                });

            var result = await _controller.Edit(model);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Disable_RedirectsOnSuccess()
        {
            _apiMock.Setup(x => x.DisableAsync(1))
                .ReturnsAsync(new SVE.Application.Common.ApiResponse<bool>
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
            var dto = new GetNetworkTypeDtos { Id = 1, Nombre = "Fibra" };

            _apiMock.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(new SVE.Application.Common.ApiResponse<GetNetworkTypeDtos>
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

