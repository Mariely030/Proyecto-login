using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Repositories;
using SVE.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SVE.Persistence.Test
{
    public class ProductoRepositoryTests
    {
        
        private SVEContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<SVEContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            return new SVEContext(options);
        }

       
        [Fact]
        public async Task SaveEntityAsync_ShouldAddProducto()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            var producto = new Producto { Nombre = "Refresco", Precio = 100, Categoria = "Bebidas" };

            var result = await repo.SaveEntityAsync(producto);

            Assert.True(result.Success);
            Assert.Equal("Producto guardado correctamente.", result.Message);
            Assert.Equal(1, context.Productos.Count());
        }

        [Fact]
        public async Task SaveEntityAsync_ShouldFailIfNombreIsEmpty()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            var producto = new Producto { Nombre = "", Precio = 100, Categoria = "Bebidas" };

            var result = await repo.SaveEntityAsync(producto);

            Assert.False(result.Success);
            Assert.Equal("El nombre del producto es obligatorio.", result.Message);
        }

        [Fact]
        public async Task SaveEntityAsync_ShouldFailIfPrecioIsZeroOrNegative()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            var producto = new Producto { Nombre = "Refresco", Precio = 0, Categoria = "Bebidas" };

            var result = await repo.SaveEntityAsync(producto);

            Assert.False(result.Success);
            Assert.Equal("El precio debe ser mayor a 0.", result.Message);
        }

        [Fact]
        public async Task UpdateEntityAsync_ShouldUpdateProducto()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            var producto = new Producto { Nombre = "Agua", Precio = 80, Categoria = "Bebidas" };
            await repo.SaveEntityAsync(producto);

            producto.Precio = 90;
            var result = await repo.UpdateEntityAsync(producto);

            Assert.True(result.Success);
            Assert.Equal(90, context.Productos.First().Precio);
        }

        [Fact]
        public async Task UpdateEntityAsync_ShouldFailIfProductoNotFound()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            var producto = new Producto { Id = 999, Nombre = "NoExiste", Precio = 50, Categoria = "Otros" };

            var result = await repo.UpdateEntityAsync(producto);

            Assert.False(result.Success);
            Assert.Equal("No se encontró el producto a actualizar.", result.Message);
        }

        [Fact]
        public async Task GetProductoByNombre_ShouldReturnMatchingProductos()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            await repo.SaveEntityAsync(new Producto { Nombre = "Salchicha y queso", Precio = 50, Categoria = "Empanadas" });

            var result = repo.GetProductoByNombre("Salchicha y queso");

            Assert.True(result.Success);
            Assert.Single((List<Producto>)result.Data);
        }

        [Fact]
        public async Task GetProductoByCategoria_ShouldReturnMatchingProductos()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            await repo.SaveEntityAsync(new Producto { Nombre = "Pollo y queso", Precio = 20, Categoria = "Empanadas" });

            var result = repo.GetProductoByCategoria("Empanadas");

            Assert.True(result.Success);
            Assert.Single((List<Producto>)result.Data);
        }

        
        [Fact]
        public async Task GetProductoByPrecio_ShouldReturnMatchingProductos()
        {
            var context = GetDbContext();
            var repo = new ProductoRepository(context);
            await repo.SaveEntityAsync(new Producto { Nombre = "Jugo", Precio = 30, Categoria = "Bebidas" });

            var result = repo.GetProductoByPrecio(30);

            Assert.True(result.Success);
            Assert.Single((List<Producto>)result.Data);
        }
    }
}
