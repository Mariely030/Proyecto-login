using Microsoft.AspNetCore.Mvc;
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Application.Dtos.Network.NetworkType;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SVE.Web.Controllers
{
    public class NetworkProviderController : Controller
    {
        private readonly INetworkProviderService _service;
        private readonly INetworkTypeService _networkTypeService;

        public NetworkProviderController(
            INetworkProviderService service,
            INetworkTypeService networkTypeService)
        {
            _service = service;
            _networkTypeService = networkTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            var list = result.Data as List<GetNetworkProviderDtos> ?? new List<GetNetworkProviderDtos>();
            return View(list);
        }

        // Crear GET
        public async Task<IActionResult> Create()
        {
            var networkTypes = await _networkTypeService.GetAllAsync();
            ViewBag.NetworkTypes = ((List<GetNetworkTypeDtos>)networkTypes.Data)
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre })
                .ToList();

            return View(new CreateNetworkProviderDtos());
        }

        // Crear POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateNetworkProviderDtos dto)
        {
            if (!ModelState.IsValid)
            {
                var networkTypes = await _networkTypeService.GetAllAsync();
                ViewBag.NetworkTypes = ((List<GetNetworkTypeDtos>)networkTypes.Data)
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre })
                    .ToList();

                return View(dto);
            }

            // Llenar Description desde el NetworkType seleccionado
            var ntResult = await _networkTypeService.GetByIdAsync(dto.NetworkTypeId);
            if (ntResult.Data is GetNetworkTypeDtos nt)
            {
                dto.Description = nt.Nombre;
            }

            dto.CreateAt = DateTime.UtcNow;

            await _service.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Edit GET
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success || result.Data is not GetNetworkProviderDtos data)
                return NotFound();

            var dto = new ModifyNetworkProviderDtos
            {
                Id = data.Id,
                Nombre = data.Nombre,
                NetworkTypeId = data.NetworkTypeId,
                Description = data.Description,
                UpdateAt = DateTime.UtcNow
            };

            var networkTypes = await _networkTypeService.GetAllAsync();
            ViewBag.NetworkTypes = ((List<GetNetworkTypeDtos>)networkTypes.Data)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nombre,
                    Selected = x.Id == data.NetworkTypeId
                }).ToList();

            return View(dto);
        }

        // Edit POST
        [HttpPost]
        public async Task<IActionResult> Edit(ModifyNetworkProviderDtos dto)
        {
            if (!ModelState.IsValid)
            {
                var networkTypes = await _networkTypeService.GetAllAsync();
                ViewBag.NetworkTypes = ((List<GetNetworkTypeDtos>)networkTypes.Data)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Nombre,
                        Selected = x.Id == dto.NetworkTypeId
                    }).ToList();

                return View(dto);
            }

            // Si Description está vacía, mantener la que ya estaba
            if (string.IsNullOrEmpty(dto.Description))
            {
                var existing = await _service.GetByIdAsync(dto.Id);
                if (existing.Data is GetNetworkProviderDtos oldData)
                {
                    dto.Description = oldData.Description;
                }
            }

            dto.UpdateAt = DateTime.UtcNow;

            await _service.UpdateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        // Disable
        public async Task<IActionResult> Disable(int id)
        {
            var dto = new DisableNetworkProviderDtos
            {
                Id = id,
                UpdateAt = DateTime.UtcNow
            };

            await _service.DeleteAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
{
    var result = await _service.GetByIdAsync(id);

    if (!result.Success || result.Data is not GetNetworkProviderDtos data)
        return NotFound();

    return View(data);

    }
}
}
