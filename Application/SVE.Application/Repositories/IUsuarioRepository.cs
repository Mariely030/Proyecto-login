using SVE.Domain.Repository;
using SVE.Domain.Entities.Configuration;

namespace SVE.Application.Repositories
{

    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {

        List<Usuario> GetUsuarioByNombre(string Nombre);
        List<Usuario> GetUsuarioByCorreo(string Correo);
        List<Usuario> GetUsuarioByRol(string Rol);
    }
}