using Microsoft.AspNetCore.Mvc;
using SVE.Application.Interfaces;
using SVE.Application.Dtos.Configuration;
using SVE.Domain.Entities.Configuration;

namespace SVE.Web.Controllers
{
    public class DetallePedidoController : Controller
    {
        private readonly IDetallePedidoService _detallePedidoService;

        public DetallePedidoController(IDetallePedidoService detallePedidoService)
        {
            _detallePedidoService = detallePedidoService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _detallePedidoService.GetDetallePedido();

            var detalles = (result.Data as IEnumerable<DetallePedido>)?.Select(d => new ReadDetallePedidoDto
            {

                Id = d.Id,
                PedidoId = d.PedidoId,
                ProductoId = d.ProductoId,
                PromocionId = d.PromocionId,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario
            }).ToList() ?? new List<ReadDetallePedidoDto>();

            return View(detalles);
        }

        public IActionResult Create() => View();

        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(CreateDetallePedidoDto model)
{
    if (!ModelState.IsValid)
        return View(model);

    var result = await _detallePedidoService.CreateDetallePedido(model);

    if (!result.Success)
    {
        // Mostrar error en la vista
        ModelState.AddModelError(string.Empty, result.Message ?? "No se pudo crear el detalle.");
        return View(model);
    }

    return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
{
    var detalleResult = await _detallePedidoService.GetDetallePedidoById(id);

    if (!detalleResult.Success || detalleResult.Data == null)
        return NotFound();

    var data = detalleResult.Data as DetallePedido;

    if (data == null)
        return NotFound();

    var model = new UpdateDetallePedidoDto
    {
        Id = data.Id,
        PedidoId = data.PedidoId,
        ProductoId = data.ProductoId,
        PromocionId = data.PromocionId,
        Cantidad = data.Cantidad,
        PrecioUnitario = data.PrecioUnitario
    };

    return View(model);
}


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDetallePedidoDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _detallePedidoService.UpdateDetallePedido(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(RemoveDetallePedidoDto model)
        {
            await _detallePedidoService.RemoveDetallePedido(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
