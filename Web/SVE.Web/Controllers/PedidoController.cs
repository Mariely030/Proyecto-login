using Microsoft.AspNetCore.Mvc;
using SVE.Application.Interfaces;
using SVE.Application.Dtos.Configuration;
using SVE.Domain.Entities.Configuration;

namespace SVE.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _pedidoService.GetPedidos();
            var pedidos = (result.Data as IEnumerable<Pedido>)?.Select(p => new ReadPedidoDto
            {
                
        Id = p.Id,
        UsuarioId = p.UsuarioId,
        Fecha = p.Fecha,
        Estado = p.Estado,
        Total = p.Total
    }).ToList() ?? new List<ReadPedidoDto>();
            return View(pedidos);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePedidoDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _pedidoService.CreatePedido(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pedidoResult = await _pedidoService.GetPedidoById(id);
            if (!pedidoResult.Success || pedidoResult.Data == null)
                return NotFound();

            var pedido = pedidoResult.Data as Pedido;
            if (pedido == null)
                return NotFound();

            var model = new UpdatePedidoDto
            {
                UsuarioId = pedido.UsuarioId,
                Fecha = pedido.Fecha,
                Total = pedido.Total,
                Estado = pedido.Estado
            };

            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(UpdatePedidoDto model)
{
    if (!ModelState.IsValid)
        return View(model);

    var result = await _pedidoService.UpdatePedido(model);

    if (!result.Success)
    {
        ModelState.AddModelError(string.Empty, result.Message ?? "Ocurrió un error al actualizar el pedido.");
        return View(model);
    }

    return RedirectToAction(nameof(Index));
}

        public async Task<IActionResult> Delete(RemovePedidoDto model)
        {
            await _pedidoService.RemovePedido(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
