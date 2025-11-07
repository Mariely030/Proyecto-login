using Xunit;
using Microsoft.EntityFrameworkCore;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Context;
using SVE.Persistence.Repositories;
using SVE.Domain.Base;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SVE.Persistence.Test
{
    public class UnitTestPromocion
    {
        private SVEContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<SVEContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new SVEContext(options);
        }

        [Fact]
        public async Task SaveEntityAsync_DeberiaGuardarPromocionCorrectamente()
        {
            var context = GetInMemoryDbContext();
            var repository = new PromocionRepository(context);

            var promocion = new Promocion { Descripcion = "Descuento 10%", Descuento = 10, Activa = true };

            var result = await repository.SaveEntityAsync(promocion);

            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal("Descuento 10%", ((Promocion)result.Data).Descripcion);
        }

        [Fact]
        public async Task SaveEntityAsync_DeberiaFallarSiDescripcionVacia()
        {
            var context = GetInMemoryDbContext();
            var repository = new PromocionRepository(context);

            var promocion = new Promocion { Descripcion = "", Descuento = 5, Activa = true };

            var result = await repository.SaveEntityAsync(promocion);

            Assert.False(result.Success);
            Assert.Equal("La descripcion es obligatoria.", result.Message);
        }

        [Fact]
        public async Task SaveEntityAsync_DeberiaFallarSiDescuentoCero()
        {
            var context = GetInMemoryDbContext();
            var repository = new PromocionRepository(context);

            var promocion = new Promocion { Descripcion = "Promo sin descuento", Descuento = 0, Activa = true };

            var result = await repository.SaveEntityAsync(promocion);

            Assert.False(result.Success);
            Assert.Equal("El descuento debe ser mayor a 0.", result.Message);
        }

        [Fact]
        public async Task UpdateEntityAsync_DeberiaActualizarPromocionCorrectamente()
        {
            var context = GetInMemoryDbContext();
            var repository = new PromocionRepository(context);

            var promo = new Promocion { Descripcion = "Vieja", Descuento = 5, Activa = true };
            await context.Promociones.AddAsync(promo);
            await context.SaveChangesAsync();

            promo.Descripcion = "Nueva";
            promo.Descuento = 15;

            var result = await repository.UpdateEntityAsync(promo);

            Assert.True(result.Success);
            Assert.Equal("Nueva", ((Promocion)result.Data).Descripcion);
        }

        [Fact]
        public void GetPromocionByDescripcion_DeberiaRetornarCoincidencias()
        {
            var context = GetInMemoryDbContext();
            context.Promociones.AddRange(
                new Promocion { Descripcion = "Promo 1", Descuento = 10, Activa = true },
                new Promocion { Descripcion = "Promo 2", Descuento = 20, Activa = false }
            );
            context.SaveChanges();

            var repository = new PromocionRepository(context);

            var result = repository.GetPromocionByDescripcion("Promo");
            var lista = result.Data as List<Promocion>;

            Assert.True(result.Success);
            Assert.Equal(2, lista.Count);
        }

        [Fact]
        public void GetPromocionByDescuento_DeberiaRetornarCorrecta()
        {
            var context = GetInMemoryDbContext();
            context.Promociones.AddRange(
                new Promocion { Descripcion = "Promo 10", Descuento = 10, Activa = true },
                new Promocion { Descripcion = "Promo 20", Descuento = 20, Activa = false }
            );
            context.SaveChanges();

            var repository = new PromocionRepository(context);

            var result = repository.GetPromocionByDescuento(10);
            var lista = result.Data as List<Promocion>;
            var promo = lista.First();

            Assert.True(result.Success);
            Assert.Single(lista);
            Assert.Equal(10, promo.Descuento);
        }

        [Fact]
        public void GetPromocionByActiva_DeberiaRetornarSoloActivas()
        {
            var context = GetInMemoryDbContext();
            context.Promociones.AddRange(
                new Promocion { Descripcion = "Promo A", Descuento = 10, Activa = true },
                new Promocion { Descripcion = "Promo B", Descuento = 15, Activa = false }
            );
            context.SaveChanges();

            var repository = new PromocionRepository(context);

            var result = repository.GetPromocionByActiva(true);
            var lista = result.Data as List<Promocion>;
            var promo = lista.First();

            Assert.True(result.Success);
            Assert.Single(lista);
            Assert.True(promo.Activa);
        }
    }
}


