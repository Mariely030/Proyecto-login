using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;

namespace SVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productoRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productoRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _productoRepository.AddAsync(producto);
            await _productoRepository.SaveChangesAsync();

            return Ok(new { message = "Producto creado correctamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id) return BadRequest();

            _productoRepository.Update(producto);
            await _productoRepository.SaveChangesAsync();

            return Ok(new { message = "Producto actualizado correctamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return NotFound();

            _productoRepository.Delete(producto);
            await _productoRepository.SaveChangesAsync();

            return Ok(new { message = "Producto eliminado correctamente." });
        }
    }
}
