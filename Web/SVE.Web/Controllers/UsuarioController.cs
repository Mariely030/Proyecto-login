using Microsoft.AspNetCore.Mvc;
using SVE.Application.Interfaces;
using SVE.Application.Dtos.Configuration;
using SVE.Domain.Entities.Configuration;

namespace SVE.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _usuarioService.GetUsuario();

            var usuarios = (result.Data as IEnumerable<Usuario>)?
                .Select(u => new ReadUsuarioDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    Rol = u.Rol
                }).ToList() ?? new List<ReadUsuarioDto>();

            return View(usuarios);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUsuarioDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _usuarioService.CreateUsuario(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuarioResult = await _usuarioService.GetUsuarioById(id);

            if (!usuarioResult.Success || usuarioResult.Data == null)
                return NotFound();

            var usuario = usuarioResult.Data as Usuario;
            if (usuario == null)
                return NotFound();

            var model = new UpdateUsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUsuarioDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _usuarioService.UpdateUsuario(model);
            return RedirectToAction(nameof(Index));
        }

       
        [HttpPost]
        public async Task<IActionResult> Delete(RemoveUsuarioDto model)
        {
            await _usuarioService.RemoveUsuario(model);
            return RedirectToAction(nameof(Index));
        }
    }
}



  