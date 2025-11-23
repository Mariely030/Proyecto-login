using Microsoft.AspNetCore.Mvc;
using SVE.Application.Dtos.Network.NetworkType;

public class NetworkTypeController : Controller
{
    private readonly INetworkTypeApi _networkTypeApi;

    public NetworkTypeController(INetworkTypeApi networkTypeApi)
    {
        _networkTypeApi = networkTypeApi;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _networkTypeApi.GetAllAsync();
        return View(result.Data ?? new List<GetNetworkTypeDtos>());
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateNetworkTypeDtos model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _networkTypeApi.CreateAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var result = await _networkTypeApi.GetByIdAsync(id);

        if (result.Data == null)
            return NotFound();

        var dto = result.Data;

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

        model.UpdateAt = DateTime.UtcNow;

        await _networkTypeApi.UpdateAsync(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Disable(int id)
    {
        await _networkTypeApi.DisableAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _networkTypeApi.GetByIdAsync(id);

        if (result.Data == null)
            return NotFound();

        return View(result.Data);
    }
}

