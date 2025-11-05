using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;

namespace SVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pedidoRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pedidoRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pedido pedido)
        {
            await _pedidoRepository.AddAsync(pedido);
            await _pedidoRepository.SaveChangesAsync();
            return Ok(new { message = "Pedido creado correctamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest();
            _pedidoRepository.Update(pedido);
            await _pedidoRepository.SaveChangesAsync();
            return Ok(new { message = "Pedido actualizado correctamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null) return NotFound();
            _pedidoRepository.Delete(pedido);
            await _pedidoRepository.SaveChangesAsync();
            return Ok(new { message = "Pedido eliminado correctamente." });
        }
    }
}
