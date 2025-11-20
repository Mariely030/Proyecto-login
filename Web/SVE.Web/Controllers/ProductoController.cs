using Microsoft.AspNetCore.Mvc;
using SVE.Application.Interfaces;
using SVE.Application.Dtos.Configuration;
using SVE.Domain.Entities.Configuration;

namespace SVE.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productoService.GetProductos();

            var productos = (result.Data as IEnumerable<Producto>)?.Select(p => new ReadProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Categoria = p.Categoria
            }).ToList() ?? new List<ReadProductoDto>();

            return View(productos);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductoDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _productoService.CreateProducto(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var productoResult = await _productoService.GetProductoById(id);

            if (!productoResult.Success || productoResult.Data == null)
                return NotFound();

            var producto = productoResult.Data as Producto;

            if (producto == null)
                return NotFound();

            var model = new UpdateProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductoDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _productoService.UpdateProducto(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(RemoveProductoDto model)
        {
            await _productoService.RemoveProducto(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
