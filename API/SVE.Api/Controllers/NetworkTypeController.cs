using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Repositories.Network;
using SVE.Application.Dtos.Network.NetworkType;

namespace SVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkTypeController : ControllerBase
    {
        private readonly INetworkTypeRepository _networkTypeRepository;

        public NetworkTypeController(INetworkTypeRepository networkTypeRepository)
        {
            _networkTypeRepository = networkTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _networkTypeRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _networkTypeRepository.GetByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNetworkTypeDtos dto)
        {
            var result = await _networkTypeRepository.AddAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModifyNetworkTypeDtos dto)
        {
            if (id != dto.Id) return BadRequest();
            var result = await _networkTypeRepository.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Disable(int id, [FromBody] DisableNetworkTypeDtos dto)
        {
            if (id != dto.Id) return BadRequest();
            var result = await _networkTypeRepository.DeleteAsync(dto);
            return Ok(result);
        }
    }
}
