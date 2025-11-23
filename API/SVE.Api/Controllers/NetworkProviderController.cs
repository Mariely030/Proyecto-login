using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Application.Common;

namespace SVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkProviderController : ControllerBase
    {
        private readonly INetworkProviderService _service;

        public NetworkProviderController(INetworkProviderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
public async Task<IActionResult> Create(CreateNetworkProviderDtos dto)
{
    var result = await _service.AddAsync(dto);

    return Ok(new ApiResponse<bool>
    {
        Success = result.Success,
        Message = result.Message,
        Data = result.Success
    });
}


       [HttpPut]
public async Task<IActionResult> Update(ModifyNetworkProviderDtos dto)
{
    var result = await _service.UpdateAsync(dto);

    return Ok(new ApiResponse<bool>
    {
        Success = result.Success,
        Message = result.Message,
        Data = result.Success
    });
}


       [HttpDelete("{id}")]
public async Task<IActionResult> Disable(int id)
{
    var dto = new DisableNetworkProviderDtos
    {
        Id = id,
        UpdateAt = DateTime.UtcNow
    };

    var result = await _service.DeleteAsync(dto);

    return Ok(new ApiResponse<bool>
    {
        Success = result.Success,
        Message = result.Message,
        Data = result.Success
    });
}

    }
}
