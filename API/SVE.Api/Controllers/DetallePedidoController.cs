using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Repositories;
using SVE.Application.Dtos;
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
        public async Task<IActionResult> Create([FromBody] CreateDetallePedidoDto dto)
        {

if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var detalle = new DetallePedido
            {
                PedidoId = dto.PedidoId,
                ProductoId = dto.ProductoId,
                PromocionId = dto.PromocionId,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario,
                FechaCreacion = DateTime.UtcNow,
                FechaActualizacion = DateTime.UtcNow
            };

            await _detallePedidoRepository.AddAsync(detalle);
            await _detallePedidoRepository.SaveChangesAsync();
            return Ok(new { message = "Detalle de pedido creado correctamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDetallePedidoDto dto)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

  
    var detalle = await _detallePedidoRepository.GetByIdAsync(id);

    if (detalle == null)
        return NotFound(new { message = $"No se encontró el detalle con Id {id}" });

    if (id != dto.Id)
        return BadRequest(new { message = "El ID del detalle no coincide con el ID enviado." });

    detalle.PedidoId = dto.PedidoId;
    detalle.ProductoId = dto.ProductoId;
    detalle.PromocionId = dto.PromocionId;
    detalle.Cantidad = dto.Cantidad;
    detalle.PrecioUnitario = dto.PrecioUnitario;

    _detallePedidoRepository.Update(detalle);
    await _detallePedidoRepository.SaveChangesAsync();

    return Ok(new
    {
        message = "Detalle de pedido actualizado correctamente.",
        detalle
    });
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
