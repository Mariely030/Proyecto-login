using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Dtos.Network.NetworkType;

namespace SVE.Web.Controllers
{
    public class NetworkTypeController : Controller
    {
        private readonly INetworkTypeService _service;

        public NetworkTypeController(INetworkTypeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();

            var list = result.Data as List<GetNetworkTypeDtos>;

            return View(result.Data as List<GetNetworkTypeDtos>);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateNetworkTypeDtos model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.Success || result.Data == null)
                return NotFound();

            var dto = result.Data as GetNetworkTypeDtos;

            if (dto == null)
                return NotFound();

            var model = new ModifyNetworkTypeDtos
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                UpdateAt = DateTime.UtcNow
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModifyNetworkTypeDtos model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Disable(int id)
        {
            var model = new DisableNetworkTypeDtos
            {
                Id = id,
                UpdateAt = DateTime.UtcNow
            };

            await _service.DeleteAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
{
    var result = await _service.GetByIdAsync(id);

    if (!result.Success || result.Data is not GetNetworkTypeDtos data)
        return NotFound();

    return View(data);
}


    }
}
