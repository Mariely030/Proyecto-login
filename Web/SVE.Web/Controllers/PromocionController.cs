using Microsoft.AspNetCore.Mvc;
using SVE.Application.Interfaces;
using SVE.Application.Dtos.Configuration;
using SVE.Domain.Entities.Configuration;

namespace SVE.Web.Controllers
{
    public class PromocionController : Controller
    {
        private readonly IPromocionService _promocionService;

        public PromocionController(IPromocionService promocionService)
        {
            _promocionService = promocionService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _promocionService.GetPromociones();
            var promociones = (result.Data as IEnumerable<Promocion>)?.Select(p => new ReadPromocionDto
            {
                Id = p.Id,
                Descripcion = p.Descripcion,
                Descuento = p.Descuento,
                Activa = p.Activa
            }).ToList() ?? new List<ReadPromocionDto>();
    
            return View(promociones);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePromocionDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _promocionService.CreatePromocion(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var promocionResult = await _promocionService.GetPromocionById(id);
            if (!promocionResult.Success || promocionResult.Data == null)
        return NotFound();

    var promocion = promocionResult.Data as Promocion;
    if (promocion == null)
        return NotFound();

    var model = new UpdatePromocionDto
    {
        Id = promocion.Id,
        Descripcion = promocion.Descripcion,
        Descuento = promocion.Descuento,
        Activa = promocion.Activa
    };

    return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePromocionDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _promocionService.UpdatePromocion(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(RemovePromocionDto model)
        {
            await _promocionService.RemovePromocion(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
