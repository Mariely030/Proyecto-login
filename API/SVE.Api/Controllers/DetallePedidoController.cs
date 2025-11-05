using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;

namespace SVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoRepository _detallePedidoRepository;

        public DetallePedidoController(IDetallePedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _detallePedidoRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _detallePedidoRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetallePedido detalle)
        {
            await _detallePedidoRepository.AddAsync(detalle);
            await _detallePedidoRepository.SaveChangesAsync();
            return Ok(new { message = "Detalle de pedido creado correctamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetallePedido detalle)
        {
            if (id != detalle.Id) return BadRequest();
            _detallePedidoRepository.Update(detalle);
            await _detallePedidoRepository.SaveChangesAsync();
            return Ok(new { message = "Detalle de pedido actualizado correctamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detalle = await _detallePedidoRepository.GetByIdAsync(id);
            if (detalle == null) return NotFound();
            _detallePedidoRepository.Delete(detalle);
            await _detallePedidoRepository.SaveChangesAsync();
            return Ok(new { message = "Detalle de pedido eliminado correctamente." });
        }
    }
}
