using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;

namespace SVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocionController : ControllerBase
    {
        private readonly IPromocionRepository _promocionRepository;

        public PromocionController(IPromocionRepository promocionRepository)
        {
            _promocionRepository = promocionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _promocionRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _promocionRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Promocion promocion)
        {
            await _promocionRepository.AddAsync(promocion);
            await _promocionRepository.SaveChangesAsync();
            return Ok(new { message = "Promoción creada correctamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Promocion promocion)
        {
            if (id != promocion.Id) return BadRequest();
            _promocionRepository.Update(promocion);
            await _promocionRepository.SaveChangesAsync();
            return Ok(new { message = "Promoción actualizada correctamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var promocion = await _promocionRepository.GetByIdAsync(id);
            if (promocion == null) return NotFound();
            _promocionRepository.Delete(promocion);
            await _promocionRepository.SaveChangesAsync();
            return Ok(new { message = "Promoción eliminada correctamente." });
        }
    }
}
