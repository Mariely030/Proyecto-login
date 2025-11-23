using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Repositories.Network;
using SVE.Application.Dtos.Network.NetworkType;
using SVE.Application.Common;

namespace SVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkTypeController : ControllerBase
    {
        private readonly INetworkTypeRepository _repo;

        public NetworkTypeController(INetworkTypeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            return Ok(result); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNetworkTypeDtos dto)
        {
            var result = await _repo.AddAsync(dto);

    return Ok(new ApiResponse<bool>
    {
        Success = result.Success,
        Message = result.Message,
        Data = result.Success
    });
}

       [HttpPut]
public async Task<IActionResult> Update([FromBody] ModifyNetworkTypeDtos dto)
{
    dto.UpdateAt = DateTime.UtcNow;

    var result = await _repo.UpdateAsync(dto);

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
    var result = await _repo.DeleteAsync(new DisableNetworkTypeDtos
    {
        Id = id,
        UpdateAt = DateTime.UtcNow
    });

    return Ok(new ApiResponse<bool>
    {
        Success = result.Success,
        Message = result.Message,
        Data = result.Success
    });
}

    }
}

