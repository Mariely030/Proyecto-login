using Xunit;
using Moq;
using SVE.Application.Services;
using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;
using SVE.Application.Dtos;

namespace SVE.Application.Test
{
    public class UsuarioServiceTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepoMock;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioRepoMock = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_usuarioRepoMock.Object);
        }

        [Fact]
        public async Task GetUsuario_DeberiaRetornarListaDeUsuarios()
        {
        
            var usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Rosse", Correo = "rosse@example.com", Rol = "Admin" },
                new Usuario { Id = 2, Nombre = "Carlos", Correo = "carlos@example.com", Rol = "Empleado" }
            };

            _usuarioRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(usuarios);

            var result = await _usuarioService.GetUsuario();

            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.IsType<List<Usuario>>(result.Data);
        }

        [Fact]
        public async Task GetUsuarioById_DeberiaRetornarUsuarioPorId()
        {
           
            var usuario = new Usuario { Id = 1, Nombre = "Rosse", Correo = "rosse@example.com", Rol = "Admin" };
            _usuarioRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(usuario);

            var result = await _usuarioService.GetUsuarioById(1);

            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            var data = Assert.IsType<Usuario>(result.Data);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task CreateUsuario_DeberiaCrearUsuarioCorrectamente()
        {
            
            var dto = new CreateUsuarioDto
            {
                Nombre = "Rosse",
                Correo = "rosse@example.com",
                Rol = "Admin"
            };

            _usuarioRepoMock.Setup(r => r.AddAsync(It.IsAny<Usuario>()))
                            .Returns(Task.CompletedTask);

            var result = await _usuarioService.CreateUsuario(dto);

            Assert.True(result.Success);
            Assert.Equal("Usuario creado correctamente", result.Message);
        }

        [Fact]
        public async Task UpdateUsuario_DeberiaActualizarUsuarioExistente()
        {
            
            var dto = new UpdateUsuarioDto
            {
                Id = 1,
                Nombre = "Rosse Actualizada",
                Correo = "rosse@correo.com",
                Rol = "Admin"
            };

            var usuario = new Usuario { Id = 1, Nombre = "Rosse", Correo = "rosse@old.com", Rol = "User" };
            _usuarioRepoMock.Setup(r => r.GetByIdAsync(dto.Id)).ReturnsAsync(usuario);

            var result = await _usuarioService.UpdateUsuario(dto);

            Assert.True(result.Success);
            Assert.Equal("Usuario actualizado correctamente", result.Message);
            _usuarioRepoMock.Verify(r => r.Update(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUsuario_DeberiaFallarSiUsuarioNoExiste()
        {
           
            var dto = new UpdateUsuarioDto { Id = 99, Nombre = "Desconocido" };
            _usuarioRepoMock.Setup(r => r.GetByIdAsync(dto.Id)).ReturnsAsync((Usuario)null);

            var result = await _usuarioService.UpdateUsuario(dto);

            Assert.False(result.Success);
            Assert.Equal("Usuario no encontrado", result.Message);
        }

        [Fact]
        public async Task RemoveUsuario_DeberiaEliminarUsuarioCorrectamente()
        {
            
            var dto = new RemoveUsuarioDto { Id = 1 };
            var usuario = new Usuario { Id = 1, Nombre = "Rosse" };
            _usuarioRepoMock.Setup(r => r.GetByIdAsync(dto.Id)).ReturnsAsync(usuario);

            var result = await _usuarioService.RemoveUsuario(dto);

            Assert.True(result.Success);
            Assert.Equal("Usuario eliminado correctamente", result.Message);
            _usuarioRepoMock.Verify(r => r.Delete(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public async Task RemoveUsuario_DeberiaFallarSiUsuarioNoExiste()
        {
          
            var dto = new RemoveUsuarioDto { Id = 99 };
            _usuarioRepoMock.Setup(r => r.GetByIdAsync(dto.Id)).ReturnsAsync((Usuario)null);

            
            var result = await _usuarioService.RemoveUsuario(dto);

            Assert.False(result.Success);
            Assert.Equal("Usuario no encontrado", result.Message);
        }
    }
}

