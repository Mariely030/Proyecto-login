using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Application.Dtos.Network.NetworkType;

public class NetworkProviderController : Controller
{
    private readonly INetworkProviderApi _api;
    private readonly INetworkTypeApi _networkTypeApi;

    public NetworkProviderController(
        INetworkProviderApi api,
        INetworkTypeApi networkTypeApi)
    {
        _api = api;
        _networkTypeApi = networkTypeApi;
    }

   
    public async Task<IActionResult> Index()
    {
        var result = await _api.GetAllAsync();
        return View(result.Data ?? new List<GetNetworkProviderDtos>());
    }

    public async Task<IActionResult> Create()
    {
        await LoadNetworkTypes();
        return View(new CreateNetworkProviderDtos());
    } 

    [HttpPost]
    public async Task<IActionResult> Create(CreateNetworkProviderDtos dto)
    {
        if (!ModelState.IsValid)
        {
            await LoadNetworkTypes();
            return View(dto);
        }

        var nt = await _networkTypeApi.GetByIdAsync(dto.NetworkTypeId);
        dto.Description = nt.Data?.Nombre ?? "";

        dto.CreateAt = DateTime.UtcNow;

        await _api.CreateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var result = await _api.GetByIdAsync(id);
        if (result.Data == null)
            return NotFound();

        var dto = new ModifyNetworkProviderDtos
        {
            Id = result.Data.Id,
            Nombre = result.Data.Nombre,
            NetworkTypeId = result.Data.NetworkTypeId,
            Description = result.Data.Description,
            UpdateAt = DateTime.UtcNow
        };

        await LoadNetworkTypes(result.Data.NetworkTypeId);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ModifyNetworkProviderDtos dto)
    {
        if (!ModelState.IsValid)
        {
            await LoadNetworkTypes(dto.NetworkTypeId);
            return View(dto);
        }

        if (string.IsNullOrWhiteSpace(dto.Description))
        {
            var existing = await _api.GetByIdAsync(dto.Id);
            dto.Description = existing.Data?.Description ?? "";
        }

        dto.UpdateAt = DateTime.UtcNow;

        await _api.UpdateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Disable(int id)
    {
        await _api.DisableAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _api.GetByIdAsync(id);
        if (result.Data == null)
            return NotFound();

        return View(result.Data);
    }

    private async Task LoadNetworkTypes(int? selectedId = null)
    {
        var networkTypes = await _networkTypeApi.GetAllAsync();

        ViewBag.NetworkTypes = (networkTypes.Data ?? new List<GetNetworkTypeDtos>())
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre,
                Selected = selectedId.HasValue && selectedId.Value == x.Id
            })
            .ToList();
    }
}



