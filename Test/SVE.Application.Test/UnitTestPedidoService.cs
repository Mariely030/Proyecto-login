using Xunit;
using Moq;
using SVE.Application.Services;
using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;
using SVE.Application.Dtos;

namespace SVE.Application.Test
{
    public class UnitTestPedidoService
    {
        private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
        private readonly PedidoService _pedidoService;

        public UnitTestPedidoService()
        {
            _pedidoRepositoryMock = new Mock<IPedidoRepository>();
            _pedidoService = new PedidoService(_pedidoRepositoryMock.Object);
        }

        [Fact]
        public async Task GetPedidos_ShouldReturnAllPedidos()
        {
          
            var pedidos = new List<Pedido> {
                new Pedido { Id = 1, Total = 100 },
                new Pedido { Id = 2, Total = 200 }
            };
            _pedidoRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(pedidos);

            var result = await _pedidoService.GetPedidos();

            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(2, ((IEnumerable<Pedido>)result.Data).Count());
        }

        [Fact]
        public async Task GetPedidoById_ShouldReturnPedido_WhenExists()
        {
            
            var pedido = new Pedido { Id = 1, Total = 150 };
            _pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(pedido);

            var result = await _pedidoService.GetPedidoById(1);

            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(150, ((Pedido)result.Data).Total);
        }

        [Fact]
        public async Task CreatePedido_ShouldAddPedidoSuccessfully()
        {
            
            var dto = new CreatePedidoDto
            {
                Fecha = DateTime.Now,
                UsuarioId = 1,
                Total = 300,
                Estado = "Pendiente"
            };

            _pedidoRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Pedido>())).Returns(Task.CompletedTask);

            var result = await _pedidoService.CreatePedido(dto);

            Assert.True(result.Success);
            Assert.Equal("Pedido creado correctamente", result.Message);
        }

        [Fact]
        public async Task UpdatePedido_ShouldUpdateSuccessfully_WhenPedidoExists()
        {
            
            var pedidoExistente = new Pedido { Id = 1, Total = 100 };
            var dto = new UpdatePedidoDto { Id = 1, Total = 200, Fecha = DateTime.Now };

            _pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(pedidoExistente);
            _pedidoRepositoryMock.Setup(repo => repo.Update(It.IsAny<Pedido>()));

            var result = await _pedidoService.UpdatePedido(dto);

            Assert.True(result.Success);
            Assert.Equal("Pedido actualizado correctamente", result.Message);
        }

        [Fact]
        public async Task UpdatePedido_ShouldFail_WhenPedidoNotFound()
        {
           
            var dto = new UpdatePedidoDto { Id = 1, Total = 200, Fecha = DateTime.Now };
            _pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Pedido?)null);

            var result = await _pedidoService.UpdatePedido(dto);

            Assert.False(result.Success);
            Assert.Equal("Pedido no encontrado", result.Message);
        }

        [Fact]
        public async Task RemovePedido_ShouldDeleteSuccessfully_WhenPedidoExists()
        {
            
            var pedido = new Pedido { Id = 1 };
            var dto = new RemovePedidoDto { Id = 1 };

            _pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(pedido);
            _pedidoRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Pedido>()));

            var result = await _pedidoService.RemovePedido(dto);

            Assert.True(result.Success);
            Assert.Equal("Pedido eliminado correctamente", result.Message);
        }

        [Fact]
        public async Task RemovePedido_ShouldFail_WhenPedidoNotFound()
        {
           
            var dto = new RemovePedidoDto { Id = 1 };
            _pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Pedido?)null);

            var result = await _pedidoService.RemovePedido(dto);

            Assert.False(result.Success);
            Assert.Equal("Pedido no encontrado", result.Message);
        }
    }
}
